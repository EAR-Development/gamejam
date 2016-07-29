using UnityEngine;
using System.Collections;

public class BaseCharacter : MonoBehaviour {

	bool isGrounded = false;
	bool facingRight = true;

	public float maxspeed = 10f;
	public float jumpForce = 400f;

	bool doubled = false;

	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	// Use this for initialization
	void Start () {
	
	}

	void FixedUpdate(){
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);


		float move = 0f;
		if (Input.GetKey (KeyCode.RightArrow)) {
			move = 1f;
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			move = -1f;
		}

		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		rb.AddForce (new Vector2 (move * maxspeed, 0));
	}

	void Update(){
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		if ((isGrounded || !doubled)&& Input.GetKeyDown (KeyCode.UpArrow)) {
			if (isGrounded) {
				doubled = false;
				rb.AddForce (new Vector2 (0, jumpForce));
			} else {
				rb.velocity = Vector3.zero; 
				doubled = true;
				rb.AddForce (new Vector2 (0, jumpForce * 0.5f));
			}
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



//	void OnTriggerEnter2D()
//	{
//		groundCounter++;
//		print("trigger enter");
//		isGrounded = true;
//		jumpCount = 0;
//	}
//
//	void OnTriggerExit2D()
//	{
//		groundCounter--;
//		print("trigger exit");
//		if (groundCounter <= 0) {
//			isGrounded = false;
//		}
//	}

}


