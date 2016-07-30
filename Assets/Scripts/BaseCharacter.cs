﻿using UnityEngine;
using System.Collections;

public class BaseCharacter : MonoBehaviour {

	bool isGrounded = false;
	bool facingRight = true;

	public float currentHp;
	public float maxHp;
	public float maxspeed = 10f;
	public float jumpForce = 400f;
	
	public float meleeAttackCounter;
	public float meleeAttackCooldown;
	
	public Rigidbody2D rb;

	bool doubled = false;

	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	public int assignedPlayer = 1;

	// Use this for initialization
	void Start () {
		spawn ();
		rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate(){
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);

		float move = Input.GetAxis ("Player" + assignedPlayer + "_x");

		
		if (Mathf.Abs(rb.velocity.x) < maxspeed) {
			rb.AddForce (new Vector2 (move * maxspeed, 0));
		}
	}


	private bool m_isAxisInUse = false;

	void Update(){
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		bool jumpKeyDown = false;

		if( Input.GetAxisRaw("Player" + assignedPlayer + "_jump") != 0){

			if(m_isAxisInUse == false)
			{
				jumpKeyDown = true;
				m_isAxisInUse = true;
			}
		}
		if( Input.GetAxisRaw("Player" + assignedPlayer + "_jump") == 0){
			m_isAxisInUse = false;
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
		
		if( Input.GetButtonDown("Player" + assignedPlayer + "_action") ){
			if( meleeAttackCounter >= meleeAttackCooldown ){
				//initiate attack
				meleeAttackCounter = 0;
			} 
		}
		
		if( meleeAttackCounter < meleeAttackCooldown ){
			meleeAttackCounter += Time.deltaTime;
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
			if(tempBlock.blockType == "Fire"){
			
			}
			else if(tempBlock.blockType == "Water"){
			
			}
			else if(tempBlock.blockType == "Bounce"){
				
			}
			else if(tempBlock.blockType == "Slow"){
				Debug.Log("slow effect");
				rb.velocity = new Vector2 ((rb.velocity.x/2), (rb.velocity.y/2)); 
				jumpForce = jumpForce / 2;
				maxspeed = maxspeed / 2;
			}
		}
	}
	
	
	void OnCollisionExit2D(Collision2D col){
		if(col.gameObject.tag == "Block"){
			Block tempBlock  = col.gameObject.GetComponent<Block>();
			if(tempBlock.blockType == "Fire"){
			
			}
			else if(tempBlock.blockType == "Water"){
			
			}
			else if(tempBlock.blockType == "Bounce"){
				
			}
			else if(tempBlock.blockType == "Slow"){
				Debug.Log("slow effect");				
				jumpForce = jumpForce * 2;
				maxspeed = maxspeed * 2;
			}
		}
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


