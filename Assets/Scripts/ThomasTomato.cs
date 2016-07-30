using UnityEngine;
using System.Collections;

public class ThomasTomato : BaseCharacter {

	// Use this for initialization
		
	void Update(){
		if(animator){
			animator.SetFloat("moveSpeed", Mathf.Abs(rb.velocity.x));
			if(isGrounded){
				animator.SetBool("isGrounded", true);
			}
			else {
				animator.SetBool("isGrounded", false);
			}
			
		}
		bool jumpKeyDown = false;

		// JUMP

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
				rb.AddForce (new Vector2 (0, jumpForce * jumpFactor));
				isGrounded = false;

				animator.SetTrigger("jump");
			} else {

				if (Input.GetAxisRaw ("Player" + assignedPlayer + "_x") < 0) {
					if (rb.velocity.x > 0) {
						print ("rechts zu rechts");
					} else {
						print ("rechts zu links");
					}
				} else {
					if (Input.GetAxisRaw ("Player" + assignedPlayer + "_x") > 0) {
						if (rb.velocity.x > 0) {
							print ("links zu rechts");
						} else {
							print ("links zu links");
						}
					}
				} 

				rb.velocity = new Vector2 (rb.velocity.x, 0); 
				doubled = true;
				rb.AddForce (new Vector2 (0, jumpForce * jumpFactor * 0.9f));
				animator.SetTrigger("jump");

			}
		}

		//ATTACK
		//Attack while standing still
		if( Input.GetButtonDown("Player" + assignedPlayer + "_action") && (Input.GetAxis ("Player" + assignedPlayer + "_x") == 0)&& (Input.GetAxis ("Player" + assignedPlayer + "_y") == 0)){
			if( meleeAttackCounter >= meleeAttackCooldown ){
				
				animator.SetBool("atkDefault",true);
				meleeAttackCounter = 0;
			} 
		}			
		//attack while moving on X		
		else if( Input.GetButtonDown("Player" + assignedPlayer + "_action") && (Input.GetAxis ("Player" + assignedPlayer + "_x") != 0)){
			if( meleeAttackCounter >= meleeAttackCooldown ){
				
				animator.SetBool("atkForward",true);
				meleeAttackCounter = 0;
			} 
		}
		//Attack up
		else if( Input.GetButtonDown("Player" + assignedPlayer + "_action") && (Input.GetAxis ("Player" + assignedPlayer + "_y") > 0)){
			if( meleeAttackCounter >= meleeAttackCooldown ){
				
				animator.SetBool("atkUp",true);
				meleeAttackCounter = 0;
			} 
		}
		//attack while moving down
		else if( Input.GetButtonDown("Player" + assignedPlayer + "_action") && (Input.GetAxis ("Player" + assignedPlayer + "_y") < 0)){
			if( meleeAttackCounter >= meleeAttackCooldown ){
				
				animator.SetBool("atkDown",true);
				meleeAttackCounter = 0;
			} 
		}
		//attack while moving up
		else if( Input.GetButtonDown("Player" + assignedPlayer + "_action") && (Input.GetAxis ("Player" + assignedPlayer + "_y") > 0)){
			if( meleeAttackCounter >= meleeAttackCooldown ){
				
				animator.SetBool("atkForward",true);
				meleeAttackCounter = 0;
			} 
		}
		
		if( meleeAttackCounter < meleeAttackCooldown ){
			meleeAttackCounter += Time.deltaTime;
		}
		
	}
	

}
