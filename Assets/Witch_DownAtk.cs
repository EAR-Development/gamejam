using UnityEngine;

public class Witch_DownAtk : StateMachineBehaviour
{
	
	public Rigidbody rb;
	public Collider[] colliders;
	public BaseCharacter characterScript;
	
    // This will be called when the animator first transitions to this state.
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		rb = animator.GetComponent<Rigidbody>();
		characterScript = animator.GetComponent<BaseCharacter>();
		colliders = characterScript.col_fists;
		
		colliders[1].enabled = true;
		colliders[0].enabled = true;
    }


    // This will be called once the animator has transitioned out of the state.
    override public void OnStateExit (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		colliders[1].enabled = false;
		colliders[0].enabled = false;
		for(int i = 0; i < characterScript.col_fists.Length; i++){
			characterScript.col_fists[i].GetComponent<Fists>().hitColliders.Clear();
		}
		characterScript.specialReady = false;
    }
	
	override public void OnStateUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		
		if(characterScript.isGrounded){
			if(characterScript.facingRight){
				rb.AddForce(new Vector2 (7, 5));
			}
			else {
				rb.AddForce(new Vector2 (-7, 5));
			}
			
		}
			
    }


    // This will be called every frame whilst in the state.
    override public void OnStateIK (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}