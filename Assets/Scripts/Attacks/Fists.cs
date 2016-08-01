using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Fists : MonoBehaviour {
	public List<Collider> hitColliders;

	// Use this for initialization
	void Start () {
		hitColliders = new List<Collider>();
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
				if(col.GetComponent<BaseCharacter>().characterClass == "ProfM" || col.GetComponent<BaseCharacter>().characterClass == "Prism"
					|| col.GetComponent<BaseCharacter>().characterClass == "Witch" ){
					col.attachedRigidbody.AddForce(transform.right * 3000);
				}
				else if(col.GetComponent<BaseCharacter>().characterClass == "3FacePlus1" || col.GetComponent<BaseCharacter>().characterClass == "ThomasTomato" ){
					col.attachedRigidbody.AddForce(-transform.right * 3000);
				}
				else if(col.GetComponent<BaseCharacter>().characterClass == "DestructionDetlef"){
					col.attachedRigidbody.AddForce(transform.forward * 3000);
				}
				//col.GetComponent<Rigidbody>().AddForce(col.transform.root.transform.forward * 500);
				BaseCharacter baseCharacter = col.gameObject.GetComponent<BaseCharacter>();

				baseCharacter.doDamage (10);	
			}
		}
	}
}
