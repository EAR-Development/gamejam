using UnityEngine;
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
	public Animator animator;

	bool doubled = false;

	public Transform groundCheck;
	float groundRadius = 0.1f;
	public LayerMask whatIsGround;

	public int assignedPlayer = 1;

	public ParticleSystem slowEffekt;


	private bool jumpkeyWasUsed = false;


	void Start () {
		spawn ();
		if(GetComponent<Animator>()){
			animator = GetComponent<Animator>();
		}
		//die();
		rb = GetComponent<Rigidbody2D>();
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
		
		if( Input.GetButtonDown("Player" + assignedPlayer + "_action") ){
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
		
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Border"){
			Debug.Log("character hit border");
			currentHp = 0;
			die();
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
		Rigidbody2D rb = GetComponent<Rigidbody2D>();

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
	
	void die(){
		animator.SetTrigger("isDead");
	}

}
	
