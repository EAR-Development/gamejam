using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Fists : MonoBehaviour {
	public List<Collider> hitColliders;

	// Use this for initialization
	void Start () {
		hitColliders = new List<Colliders>();
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
			hitColliders.Add(col);
		
			Debug.Log("player hit");
			if(transform.root.gameObject.name == "ProfM" || transform.root.gameObject.name == "ThomasTomato"){
				col.attachedRigidbody.AddForce(transform.right * 500);
			}
			else if(transform.root.gameObject.name == "3FacePlus1" ){
				col.attachedRigidbody.AddForce(-transform.right * 500);
			}
			else {
				col.attachedRigidbody.AddForce(transform.forward * 500);
			}
			//col.GetComponent<Rigidbody>().AddForce(col.transform.root.transform.forward * 500);
			BaseCharacter baseCharacter = col.gameObject.GetComponent<BaseCharacter>();

			baseCharacter.doDamage (10);	
		}
	}
}
