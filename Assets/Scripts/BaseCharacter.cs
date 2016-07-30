using UnityEngine;
using System.Collections;

public class BaseCharacter : MonoBehaviour {

	bool isGrounded = false;
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
	public ParticleSystem slowEffekt;


	[Header("Status")]
	public float currentHp;
	public float meleeAttackCounter;

	public Rigidbody rb;
	public Animator animator;
	private bool jumpkeyWasUsed = false;

	void Start () {
		//rb = GetComponent<Rigidbody>();
		spawn ();
		if(GetComponent<Animator>()){
			animator = GetComponent<Animator>();
		}
		//die();

	}
		
	void FixedUpdate(){
		checkGroundStatus ();

		float inputMovementstrength = Input.GetAxis ("Player" + assignedPlayer + "_x");
		applyHorizontalMovement (inputMovementstrength);
	}
		
	void Update(){



		if(animator){
			animator.SetFloat("moveSpeed", Mathf.Abs(rb.velocity.x));
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
				rb.AddForce (new Vector2 (0, jumpForce));
				animator.SetTrigger("jump");
			} else {
				rb.velocity = new Vector2 (rb.velocity.x, 0); 
				doubled = true;
				rb.AddForce (new Vector2 (0, jumpForce * 0.9f));
				animator.SetTrigger("jump");
			}
		}

		//ATTACK
		
		if( Input.GetButtonDown("Player" + assignedPlayer + "_action") && (Input.GetAxis ("Player" + assignedPlayer + "_x") == 0)&& (Input.GetAxis ("Player" + assignedPlayer + "_y") == 0)){
			if( meleeAttackCounter >= meleeAttackCooldown ){
				//initiate attack
				animator.SetBool("atkDefault",true);
				meleeAttackCounter = 0;
			} 
		}		
		else if( Input.GetButtonDown("Player" + assignedPlayer + "_action") && (Input.GetAxis ("Player" + assignedPlayer + "_x") != 0)){
			if( meleeAttackCounter >= meleeAttackCooldown ){
				//initiate attack
				animator.SetBool("atkForward",true);
				meleeAttackCounter = 0;
			} 
		}
		else if( Input.GetButtonDown("Player" + assignedPlayer + "_action") && (Input.GetAxis ("Player" + assignedPlayer + "_y") < 0)){
			if( meleeAttackCounter >= meleeAttackCooldown ){
				//initiate attack
				animator.SetBool("atkDown",true);
				meleeAttackCounter = 0;
			} 
		}
		else if( Input.GetButtonDown("Player" + assignedPlayer + "_action") && (Input.GetAxis ("Player" + assignedPlayer + "_y") > 0)){
			if( meleeAttackCounter >= meleeAttackCooldown ){
				//initiate attack
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
	
	void OnCollisionEnter(Collision col){
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

	void OnCollisionExit(Collision col){
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
		jumpForce = jumpForce / 2;
		maxspeed = maxspeed / 2;
		var em = slowEffekt.emission;
		em.enabled = true;
	}
	void removeSlowDebuff(){
		jumpForce = jumpForce * 2;
		maxspeed = maxspeed * 2;
		var em = slowEffekt.emission;
		em.enabled = false;
	}

	void applyHorizontalMovement(float inputMovementstrength){
		

		if (Mathf.Abs(rb.velocity.x) < maxspeed) {
			rb.AddForce (new Vector2 (inputMovementstrength * maxspeed, 0));
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
	
