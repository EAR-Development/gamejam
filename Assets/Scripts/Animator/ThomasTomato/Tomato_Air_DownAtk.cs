using UnityEngine;

public class Tomato_Air_DownAtk : StateMachineBehaviour
{
	public Rigidbody rb;
	public Collider[] colliders;
	public ThomasTomato characterScript;
	
    // This will be called when the animator first transitions to this state.
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		rb = animator.GetComponent<Rigidbody>();
		characterScript = animator.GetComponent<ThomasTomato>();
		colliders = characterScript.col_fists;
		
		colliders[0].enabled = true;
		colliders[1].enabled = true;
    }


    // This will be called once the animator has transitioned out of the state.
    override public void OnStateExit (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		colliders[0].enabled = false;
		colliders[1].enabled = false;
    }
	
	override public void OnStateUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		if(characterScript.facingRight){
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