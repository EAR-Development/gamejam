using UnityEngine;
using System.Collections;

public class Fists : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
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
			Debug.Log("player hit");
			col.attachedRigidbody.AddForce(transform.forward * 500);
			//col.GetComponent<Rigidbody>().AddForce(col.transform.root.transform.forward * 500);
		}
	}
}
