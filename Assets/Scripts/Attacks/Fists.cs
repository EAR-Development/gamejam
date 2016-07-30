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
		}
	}
}
