using UnityEngine;
using System.Collections;

public class ThomasTomato : BaseCharacter {

	// Use this for initialization
		
	//public Collider[] col_fists;

	public override void attack(){
		//ATTACK
		//Attack while standing still
		if(!useController){
			if(( Input.GetButtonDown("Player" + assignedPlayer + "_action") && (Input.GetAxis ("Player" + assignedPlayer + "_x") == 0)&& (Input.GetAxis ("Player" + assignedPlayer + "_y") == 0))){
				if(isGrounded){
					if( meleeAttackCounter >= meleeAttackCooldown ){
						audioSource.clip = audioClips[0];
						audioSource.Play();
						animator.SetBool("atkDefault",true);
						meleeAttackCounter = 0;
					} 
				}
				else if(!isGrounded){
					if( meleeAttackCounter >= meleeAttackCooldown ){
						audioSource.clip = audioClips[0];
						audioSource.Play();
						animator.SetBool("atkDefault",true);
						meleeAttackCounter = 0;
					} 
				}
			}			
			//attack while moving on X		
			else if(( Input.GetButtonDown("Player" + assignedPlayer + "_action") && (Input.GetAxis ("Player" + assignedPlayer + "_x") != 0))){
				if(isGrounded){
					if( meleeAttackCounter >= meleeAttackCooldown ){
						audioSource.clip = audioClips[0];
						audioSource.Play();
						animator.SetBool("atkForward",true);
						meleeAttackCounter = 0;
					} 
				}
				else if(!isGrounded){
					if( meleeAttackCounter >= meleeAttackCooldown ){
						audioSource.clip = audioClips[0];
						audioSource.Play();
						animator.SetBool("atkDefault",true);
						meleeAttackCounter = 0;
					} 
				}
			}
			//Attack up
			else if(( Input.GetButtonDown("Player" + assignedPlayer + "_action") && (Input.GetAxis ("Player" + assignedPlayer + "_y") > 0))){
				if( meleeAttackCounter >= meleeAttackCooldown ){
					audioSource.clip = audioClips[0];
					audioSource.Play();
					animator.SetBool("atkUp",true);
					meleeAttackCounter = 0;
				} 
			}
			//attack while moving down
			else if(( Input.GetButtonDown("Player" + assignedPlayer + "_action") && (Input.GetAxis ("Player" + assignedPlayer + "_y") < 0))){
				if( meleeAttackCounter >= meleeAttackCooldown ){
					audioSource.clip = audioClips[0];
					audioSource.Play();
					animator.SetBool("atkDown",true);
					meleeAttackCounter = 0;
				} 
			}
			//attack while moving up
			else if(( Input.GetButtonDown("Player" + assignedPlayer + "_action") && (Input.GetAxis ("Player" + assignedPlayer + "_y") > 0))){
				if( meleeAttackCounter >= meleeAttackCooldown ){
					audioSource.clip = audioClips[0];
					audioSource.Play();
					animator.SetBool("atkForward",true);
					meleeAttackCounter = 0;
				} 
			}
		}
		else if(useController){
			if(( Input.GetButtonDown("Player" + controllerNr + "_action_ctrlr") && (Input.GetAxis ("Player" + controllerNr + "_x_ctrlr") == 0)&& (Input.GetAxis ("Player" + controllerNr + "_y_ctrlr") == 0))){
				if(isGrounded){
					if( meleeAttackCounter >= meleeAttackCooldown ){
						audioSource.clip = audioClips[0];
						audioSource.Play();
						animator.SetBool("atkDefault",true);
						meleeAttackCounter = 0;
					} 
				}
				else if(!isGrounded){
					if( meleeAttackCounter >= meleeAttackCooldown ){
						audioSource.clip = audioClips[0];
						audioSource.Play();
						animator.SetBool("atkDefault",true);
						meleeAttackCounter = 0;
					} 
				}
			}			
			//attack while moving on X		
			else if(( Input.GetButtonDown("Player" + controllerNr + "_action_ctrlr") && (Input.GetAxis ("Player" + controllerNr + "_x_ctrlr") != 0))){
				if(isGrounded){
					if( meleeAttackCounter >= meleeAttackCooldown ){
						audioSource.clip = audioClips[0];
						audioSource.Play();
						animator.SetBool("atkForward",true);
						meleeAttackCounter = 0;
					} 
				}
				else if(!isGrounded){
					if( meleeAttackCounter >= meleeAttackCooldown ){
						audioSource.clip = audioClips[0];
						audioSource.Play();
						animator.SetBool("atkDefault",true);
						meleeAttackCounter = 0;
					} 
				}
			}
			//Attack up
			else if(( Input.GetButtonDown("Player" + controllerNr + "_action_ctrlr") && (Input.GetAxis ("Player" + controllerNr + "_y_ctrlr") > 0))){
				if( meleeAttackCounter >= meleeAttackCooldown ){
					audioSource.clip = audioClips[0];
					audioSource.Play();
					animator.SetBool("atkUp",true);
					meleeAttackCounter = 0;
				} 
			}
			//attack while moving down
			else if(( Input.GetButtonDown("Player" + controllerNr + "_action_ctrlr") && (Input.GetAxis ("Player" + controllerNr + "_y_ctrlr") < 0))){
				if( meleeAttackCounter >= meleeAttackCooldown ){
					audioSource.clip = audioClips[0];
					audioSource.Play();
					animator.SetBool("atkDown",true);
					meleeAttackCounter = 0;
				} 
			}
			//attack while moving up
			else if(( Input.GetButtonDown("Player" + controllerNr + "_action_ctrlr") && (Input.GetAxis ("Player" + controllerNr + "_y_ctrlr") > 0))){
				if( meleeAttackCounter >= meleeAttackCooldown ){
					audioSource.clip = audioClips[0];
					audioSource.Play();
					animator.SetBool("atkForward",true);
					meleeAttackCounter = 0;
				} 
			}
		}
		if( meleeAttackCounter < meleeAttackCooldown ){
			meleeAttackCounter += Time.deltaTime;
		}
	}

}
