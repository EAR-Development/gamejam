using UnityEngine;
using System.Collections;

public class CTF_Flag : MonoBehaviour {

	
	public int teamNr ;
	public bool pickedUp ;
	public bool captured ;
	public bool respawned = false ;
	public float respawnTime = 3.0f ;
	public GameObject ctfSpawn  ;
	public Rigidbody rb;
	public float pickUpCooldown;
	
	public Collider[] flagColliders ;

	void Start () {
		rb = GetComponent<Rigidbody>();
		ctfSpawn = GameObject.FindGameObjectWithTag("CTF_spawn");
	}

	void Update () {
		if(!pickedUp){
			if(pickUpCooldown > 0){
				pickUpCooldown -= Time.deltaTime;
			}
			else {				
				//flagColliders[0].enabled = true;
				flagColliders[1].enabled = true;
			}
		}
		
		if(captured){
			if(respawned == false){
				if(respawnTime > 0){
					respawnTime -= Time.deltaTime;
				}
				else {			
					captured = false;
					RespawnFlag();
				}
			}
			
		}
	}

	public void DropFlag(){
		teamNr = 0;
		pickedUp = false;
		transform.parent = null;
		rb.isKinematic = false;
		rb.AddForce(12, 20, 0);		
		pickUpCooldown = 1.5f;
		Debug.Log("flag dropped!");
		
	}
	
	public void CaptureFlag(){
		respawned = false;		
		pickedUp = false;
		transform.parent = null;
		teamNr = 0;
		GetComponent<MeshRenderer>().enabled = false;		
		Debug.Log("flag captured!");
	}
	
	public void RespawnFlag(){
		transform.position = ctfSpawn.transform.position;
		GetComponent<MeshRenderer>().enabled = true;
		respawned = true;
		respawnTime = 3.0f;
		Debug.Log("flag respawned!");
	}
	
	void OnCollisionEnter(Collision col){
		if(!pickedUp ){
			if(col.gameObject.tag == "Player"){		
				rb.isKinematic = true;
				//flagColliders[0].enabled = false;
				flagColliders[1].enabled = false;
				BaseCharacter playerScript = col.transform.GetComponent<BaseCharacter>();
				teamNr = playerScript.player.teamNumber;
				pickedUp = true;
				Debug.Log("flag picked up!");
				//PickUpFlag();
				Vector3 carryPos = col.transform.position;
				carryPos.y += .55f;
				transform.root.position = carryPos;
				transform.root.parent = col.transform;				
			}
			 
		}
	}
	
	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Border"){	
				DropFlag();
				respawned = false;
				respawnTime = 3.0f;
				captured = true;				
				GetComponent<MeshRenderer>().enabled = false;	
				transform.position = ctfSpawn.transform.position;
			}
	}
}
