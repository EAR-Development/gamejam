using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody rb = GetComponent<Rigidbody>();

		if (Input.GetKey (KeyCode.UpArrow)) {
			rb.AddForce (Vector3.up * 20);
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.Translate (Vector3.down * 1 * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate (Vector3.left * 1 * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate (Vector3.right * 1 * Time.deltaTime);
		}
			
	}
}
