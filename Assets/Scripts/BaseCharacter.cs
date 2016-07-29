﻿using UnityEngine;
using System.Collections;

public class BaseCharacter : MonoBehaviour {

	bool isGrounded = false;
	bool facingRight = true;

	public float currentHp;
	public float maxHp;
	public float maxspeed = 10f;
	public float jumpForce = 400f;

	bool doubled = false;

	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	public int assignedPlayer = 1;

	private bool jumpkeyWasUsed = false;

	void Start () {
		spawn ();
	}
		
	void FixedUpdate(){
		checkGroundStatus ();

		float inputMovementstrength = Input.GetAxis ("Player" + assignedPlayer + "_x");
		applyHorizontalMovement (inputMovementstrength);
	}
		
	void Update(){
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		bool jumpKeyDown = false;

		if( Input.GetAxisRaw("Player" + assignedPlayer + "_jump") != 0){

			if(jumpkeyWasUsed == false)
			{
				jumpKeyDown = true;
				jumpkeyWasUsed = true;
			}
		}
		if( Input.GetAxisRaw("Player" + assignedPlayer + "_jump") == 0){
			jumpkeyWasUsed = false;
		}  


		if ((isGrounded || !doubled) && jumpKeyDown) {
			if (isGrounded) {
				doubled = false;
				rb.AddForce (new Vector2 (0, jumpForce));
			} else {
				rb.velocity = new Vector2 (rb.velocity.x, 0); 
				doubled = true;
				rb.AddForce (new Vector2 (0, jumpForce * 0.9f));
			}
		}
	}
		
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Border"){
			Debug.Log("character hit border");
			currentHp = 0;
			spawn ();
		}
	}
	
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Block"){
			Block tempBlock  = col.gameObject.GetComponent<Block>();
			switch (tempBlock.blockType) {
			case "Fire":
				break;
			case "Water":
				break;
			case "Bounce":
				break;
			case "Slow":
				addSlowDebuff ();
				break;
			}
		}
	}

	void OnCollisionExit2D(Collision2D col){
		if(col.gameObject.tag == "Block"){
			Block tempBlock  = col.gameObject.GetComponent<Block>();
			switch (tempBlock.blockType) {
			case "Fire":
				break;
			case "Water":
				break;
			case "Bounce":
				break;
			case "Slow":
				removeSlowDebuff ();
				break;
			}
		}
	}
		
	void addSlowDebuff(){
		Debug.Log("slow effect");
		jumpForce = jumpForce / 2;
		maxspeed = maxspeed / 2;
	}
	void removeSlowDebuff(){
		Debug.Log("slow effect removed");
		jumpForce = jumpForce * 2;
		maxspeed = maxspeed * 2;
	}

	void applyHorizontalMovement(float inputMovementstrength){
		Rigidbody2D rb = GetComponent<Rigidbody2D>();

		if (Mathf.Abs(rb.velocity.x) < maxspeed) {
			rb.AddForce (new Vector2 (inputMovementstrength * maxspeed, 0));
		}
	}

	void checkGroundStatus(){
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
	}

	void spawn(){
		currentHp = maxHp;
		var gObj = GameObject.Find("Player" + assignedPlayer + "_spawn");
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		rb.velocity = Vector3.zero;
		if (gObj){
			transform.position = gObj.transform.position;
		}
	}

}
	
