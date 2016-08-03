using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Fists : MonoBehaviour {
	public List<Collider> hitColliders;
	public Rigidbody rb;
	public BaseCharacter character;

	// Use this for initialization
	void Start () {
		hitColliders = new List<Collider>();
		rb = GetComponent<Rigidbody>();
		character = transform.root.GetComponent<BaseCharacter>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision col ){
		if(col.gameObject.tag == "Player"){
			Debug.Log("player hit");
			col.rigidbody.AddForce(transform.forward * 500);
			//col.rigidbody.AddForce(col.transform.root.transform.forward * 500);
		}
	}
	
	void OnTriggerEnter(Collider col ){
		if(col.gameObject.tag == "Player"){
			
			if(hitColliders.Contains(col)){
				Debug.Log("player already hit");
			}
			else {
				hitColliders.Add(col);
				Debug.Log("player hit");
				
				//if(character.facingRight){
					if(col.GetComponent<BaseCharacter>().characterClass == "ProfM" || col.GetComponent<BaseCharacter>().characterClass == "Prism"  ){
						col.attachedRigidbody.AddForce(transform.right * 1400);
					}
					else if(  col.GetComponent<BaseCharacter>().characterClass == "ThomasTomato" || col.GetComponent<BaseCharacter>().characterClass == "Witch"){
						col.attachedRigidbody.AddForce(-transform.right * 1400);
					}
					else if(  col.GetComponent<BaseCharacter>().characterClass == "3FacePlus1" ){
						col.attachedRigidbody.AddForce(transform.forward * 1400);
					}
					else if(col.GetComponent<BaseCharacter>().characterClass == "DestructionDetlef") {
						col.attachedRigidbody.AddForce(transform.forward * 1400);
					}
				//}
				//else {
				
				//}
				//col.GetComponent<Rigidbody>().AddForce(rb * 500);
				BaseCharacter baseCharacter = col.gameObject.GetComponent<BaseCharacter>();
	
				baseCharacter.lastHit = this.transform.root.GetComponent<BaseCharacter>().player;
				baseCharacter.doDamage (10);	
			}
		}
	}
}
