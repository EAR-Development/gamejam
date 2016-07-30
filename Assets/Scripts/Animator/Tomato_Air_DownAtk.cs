using UnityEngine;

public class Tomato_Air_DownAtk : StateMachineBehaviour
{
	public Rigidbody rb;

    // This will be called when the animator first transitions to this state.
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		rb = animator.GetComponent<Rigidbody>();
    }


    // This will be called once the animator has transitioned out of the state.
    override public void OnStateExit (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
	
	override public void OnStateUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		if(animator.GetComponent<BaseCharacter>().facingRight){
			rb.AddForce(new Vector2 (21, -21));
		}
		else {
			rb.AddForce(new Vector2 (-21, -21));
		}
		
    }


    // This will be called every frame whilst in the state.
    override public void OnStateIK (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}