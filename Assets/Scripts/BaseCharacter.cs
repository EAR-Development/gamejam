using UnityEngine;
using System.Collections;

public class BaseCharacter : MonoBehaviour {

	public bool isGrounded = false;
	bool facingRight = true;

	[Header("Settings")]
	public float maxHp;
	public float maxspeed = 20f;
	public float jumpForce = 400f;

	public float meleeAttackCooldown;

	bool doubled = false;

	public Transform groundCheck;
	float groundRadius = 0.1f;
	public LayerMask whatIsGround;

	public int assignedPlayer = 1;

	[Header("Partikel")]
	public ParticleSystem slowEffect;
	public ParticleSystem fireEffect;


	[Header("Status")]
	public float currentHp;
	public float meleeAttackCounter;

	public float speedFactor = 1f;
	public float jumpFactor = 1f;

	public Rigidbody rb;
	public Animator animator;
	private bool jumpkeyWasUsed = false;

	//public float jumpCooldown;
	//public bool jumpDisabled;

	void Start () {

		//jumpDisabled = true;
		//rb = GetComponent<Rigidbody>();
		spawn ();
		if(GetComponent<Animator>()){
			animator = GetComponent<Animator>();
		}
		//die();

	}
		
	void FixedUpdate(){
		checkGroundStatus ();
		calculateDebuffFactors ();

		float inputMovementstrength = Input.GetAxis ("Player" + assignedPlayer + "_x");
		applyHorizontalMovement (inputMovementstrength);
	}
		
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
		
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Border"){
			Debug.Log("character hit border");
			currentHp = 0;
			die();
			spawn ();
		}
	}

	// DEBUFF SECTION
	int appliedSlowDebuffs = 0;
	int appliedFireDebuffs = 0;

	void calculateDebuffFactors(){
		speedFactor = 1f;
		jumpFactor = 1f;
		if (appliedSlowDebuffs > 0) {
			speedFactor *= 0.5f;
			jumpFactor *= 0.5f;
		}
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Block"){
			Block tempBlock  = col.gameObject.GetComponent<Block>();

			switch (tempBlock.blockType) {
			case "Fire":
				appliedFireDebuffs++;
				var fem = fireEffect.emission;
				fem.enabled = true;
				break;
			case "Water":
				break;
			case "Bounce":
				break;
			case "Slow":
				appliedSlowDebuffs++;
				var sem = slowEffect.emission;
				sem.enabled = true;
				break;

			}
		}
	}

	void OnCollisionExit(Collision col){
		if(col.gameObject.tag == "Block"){
			Block tempBlock  = col.gameObject.GetComponent<Block>();

			switch (tempBlock.blockType) {
			case "Fire":
				appliedFireDebuffs--;
				if (appliedSlowDebuffs == 0) {
					var fem = fireEffect.emission;
					fem.enabled = false;
				}
				break;
			case "Water":
				break;
			case "Bounce":
				break;
			case "Slow":
				appliedSlowDebuffs--;
				if (appliedSlowDebuffs == 0) {
					var sem = slowEffect.emission;
					sem.enabled = false;
				}
				break;

			}
		}
	}


	void applyHorizontalMovement(float inputMovementstrength){
		

		if (Mathf.Abs(rb.velocity.x) < maxspeed) {
			rb.AddForce (new Vector2 (inputMovementstrength * maxspeed * speedFactor, 0));
		}

		if (inputMovementstrength < 0 && facingRight) {
			facingRight = !facingRight;
			transform.Rotate(new Vector3(0,180,0));
		}
		if (inputMovementstrength > 0 && !facingRight) {

			facingRight = !facingRight;
			transform.Rotate(new Vector3(0,180,0));
		}
	}

	void checkGroundStatus(){

		isGrounded =  Physics.OverlapSphere (groundCheck.position, groundRadius, whatIsGround).Length!=0;

		
	}

	void spawn(){
		currentHp = maxHp;
		var gObj = GameObject.Find("Player" + assignedPlayer + "_spawn");

		rb.velocity = Vector3.zero;
		if (gObj){
			transform.position = gObj.transform.position;
		}
	}
	
	void die(){
		animator.SetTrigger("isDead");
	}




}
	
