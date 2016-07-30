﻿using UnityEngine;

public class ProfM_AnimFrontAtk : StateMachineBehaviour
{
	
	public Collider[] colliders;
	public BaseCharacter characterScript;
	
    // This will be called when the animator first transitions to this state.
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
	
		characterScript = animator.GetComponent<BaseCharacter>();
		colliders = characterScript.col_fists;
		
		//colliders[0].enabled = true;
		colliders[2].enabled = true;
    }


    // This will be called once the animator has transitioned out of the state.
    override public void OnStateExit (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		//colliders[0].enabled = false;
		colliders[2].enabled = false;
    }
	
	override public void OnStateUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
				
    }


    // This will be called every frame whilst in the state.
    override public void OnStateIK (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}