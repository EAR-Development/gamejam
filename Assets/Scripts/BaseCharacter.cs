using UnityEngine;
using System.Collections;

public class BaseCharacter : MonoBehaviour {

	bool isGrounded = true;
	float jumpImpulse = 4f;

	float maxspeed = 10f;

	int groundCounter = 0;
	int jumpCount = 0;

	// Use this for initialization
	void Start () {
	
	}

	void FixedUpdate(){
		float move = 0f;
		if (Input.GetKey (KeyCode.RightArrow)) {
			move = 1f;
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			move = -1f;
		}
	}
	
	// Update is called once per frame
//	void Update () {
//
//		Rigidbody2D rb = GetComponent<Rigidbody2D>();
//		var speed = rb.velocity.magnitude;
//		print (speed);
//
//		if (Input.GetKeyDown (KeyCode.UpArrow) && (isGrounded || jumpCount < 2)) {
//			rb.AddForce (Vector3.up * jumpImpulse, ForceMode2D.Impulse);
//			jumpCount++;
//		}
//
//		if (Input.GetKey (KeyCode.RightArrow) && speed < maxspeed) {
//			rb.AddForce (Vector3.right * movementSpeed * Time.deltaTime);
//		}
//		if (Input.GetKey (KeyCode.LeftArrow) && speed < maxspeed) {
//			rb.AddForce (Vector3.left * movementSpeed * Time.deltaTime);
//		}
//
//	}



	void OnTriggerEnter2D()
	{
		groundCounter++;
		print("trigger enter");
		isGrounded = true;
		jumpCount = 0;
	}

	void OnTriggerExit2D()
	{
		groundCounter--;
		print("trigger exit");
		if (groundCounter <= 0) {
			isGrounded = false;
		}
	}

}


