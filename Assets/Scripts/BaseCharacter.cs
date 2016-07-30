using UnityEngine;
using System.Collections;

public class BaseCharacter : MonoBehaviour {

	public bool isGrounded = false;
	public bool facingRight = true;

	[Header("Settings")]
	public float maxHp;
	public float maxspeed = 20f;
	public float jumpForce = 400f;

	public float meleeAttackCooldown;

	public bool doubled = false;

	public Transform groundCheck;
	public Transform frontCheck;
	public Transform backCheck;
	float groundRadius = 0.1f;
	public LayerMask whatIsGround;

	public int assignedPlayer = 1;

	public float debuffTime = 1f;
	public float fireDPS;

	public float jumpCooldown;

	public float maxAirVelocity;

	[Header("Partikel")]
	public ParticleSystem slowEffect;
	public ParticleSystem fireEffect;


	[Header("Status")]
	public float currentHp;
	public float meleeAttackCounter; 
	private bool isDead;

	public float speedFactor = 1f;
	public float jumpFactor = 1f;

	public float slowCounter = 0f;
	public float fireCounter = 0f;

	public AudioSource audioSource;
	public AudioClip[] audioClips;
	
	public Rigidbody rb;
	public Animator animator;
	public bool jumpkeyWasUsed = false;

	public bool groundCheckPause;
	public bool isFlying;
	public bool jumpingMidAir;
	public bool isSided;

	public int walljumpCounter = 3;
	
	public Collider[] col_fists;

	void Start () {

		//jumpDisabled = true;
		//rb = GetComponent<Rigidbody>();
		groundCheckPause=false;
		spawn ();
		if(GetComponent<Animator>()){
			animator = GetComponent<Animator>();
		}
		//die();

	}
		
	void FixedUpdate(){
		if(!groundCheckPause){

			checkGroundStatus ();
			checkSideStatus ();
		}

		calculateDebuffFactors ();

		float inputMovementstrength = Input.GetAxis ("Player" + assignedPlayer + "_x");
		applyHorizontalMovement (inputMovementstrength);
	}
		
	void Update(){

		if(jumpingMidAir){
			if(rb.velocity.magnitude>maxAirVelocity){
				rb.velocity *= 0.9f;

			}
		}

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
			
		if ((isGrounded || !doubled || (isSided && walljumpCounter > 0)) && jumpKeyDown) {
			if (isGrounded) {
				doubled = false;
				rb.AddForce (new Vector2 (0, jumpForce * jumpFactor));
				isGrounded = false;
				groundCheckPause = true;
				Invoke ("enableGroundCheck",jumpCooldown);

				animator.SetTrigger("jump");
			} else {

				if (Input.GetAxisRaw ("Player" + assignedPlayer + "_x") < 0) {
					Vector3 tempVel=rb.velocity;
					if (rb.velocity.x > 0) {
						//print ("rechts zu links");

						tempVel.x = tempVel.x * -1;
						rb.velocity = tempVel;


					} else {
					//	print ("rechts zu rechts");
					}
				} else {
					Vector3 tempVel=rb.velocity;
					if (Input.GetAxisRaw ("Player" + assignedPlayer + "_x") > 0) {
						if (rb.velocity.x > 0) {
							
							//print ("links zu links");
						} else {
							tempVel.x = tempVel.x * -1;
							rb.velocity = tempVel;
							//print ("links zu rechts");
						}
					}
				} 

				rb.velocity = new Vector2 (rb.velocity.x, 0);

				if (isSided && walljumpCounter > 0) {
					walljumpCounter--;
				} else {
					doubled = true;
				}
				rb.AddForce (new Vector2 (0, jumpForce * jumpFactor * 0.9f));
				animator.SetTrigger("jump");
				isGrounded = false;
				groundCheckPause = true;
				Invoke ("enableGroundCheck",jumpCooldown);

			}
		}

		//ATTACK
		//Attack while standing still
		if( Input.GetButtonDown("Player" + assignedPlayer + "_action") && (Input.GetAxis ("Player" + assignedPlayer + "_x") == 0)&& (Input.GetAxis ("Player" + assignedPlayer + "_y") == 0)){
			if( meleeAttackCounter >= meleeAttackCooldown ){
				audioSource.clip = audioClips[0];
				audioSource.Play();
				animator.SetBool("atkDefault",true);
				meleeAttackCounter = 0;
			} 
		}			
		//attack while moving on X		
		else if( Input.GetButtonDown("Player" + assignedPlayer + "_action") && (Input.GetAxis ("Player" + assignedPlayer + "_x") != 0)){
			if( meleeAttackCounter >= meleeAttackCooldown ){
				audioSource.clip = audioClips[0];
				audioSource.Play();
				animator.SetBool("atkForward",true);
				meleeAttackCounter = 0;
			} 
		}
		//Attack up
		else if( Input.GetButtonDown("Player" + assignedPlayer + "_action") && (Input.GetAxis ("Player" + assignedPlayer + "_y") > 0)){
			if( meleeAttackCounter >= meleeAttackCooldown ){
				audioSource.clip = audioClips[0];
				audioSource.Play();
				animator.SetBool("atkUp",true);
				meleeAttackCounter = 0;
			} 
		}
		//attack while moving down
		else if( Input.GetButtonDown("Player" + assignedPlayer + "_action") && (Input.GetAxis ("Player" + assignedPlayer + "_y") < 0)){
			if( meleeAttackCounter >= meleeAttackCooldown ){
				audioSource.clip = audioClips[0];
				audioSource.Play();
				animator.SetBool("atkDown",true);
				meleeAttackCounter = 0;
			} 
		}
		//attack while moving up
		else if( Input.GetButtonDown("Player" + assignedPlayer + "_action") && (Input.GetAxis ("Player" + assignedPlayer + "_y") > 0)){
			if( meleeAttackCounter >= meleeAttackCooldown ){
				audioSource.clip = audioClips[0];
				audioSource.Play();
				animator.SetBool("atkForward",true);
				meleeAttackCounter = 0;
			} 
		}
		
		if( meleeAttackCounter < meleeAttackCooldown ){
			meleeAttackCounter += Time.deltaTime;
		}

		//Debuff
		if(slowCounter > 0f){
			slowCounter -= Time.deltaTime;
			if(slowCounter <= 0f){
				var sem = slowEffect.emission;
				sem.enabled = false;
			}
		}

		if(fireCounter > 0f){
			fireCounter -= Time.deltaTime;
			doDamage(fireDPS * Time.deltaTime);
			if(fireCounter <= 0f){
				var fem = fireEffect.emission;
				fem.enabled = false;
			}
		}
	}
		
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Border"){
			
			currentHp = 0;
			die();
		}
	}

	// DEBUFF SECTION
	void calculateDebuffFactors(){
		speedFactor = 1f;
		jumpFactor = 1f;
		if (slowCounter > 0f) {
			speedFactor *= 0.5f;
			jumpFactor *= 0.5f;
		}
	}

	void OnCollisionStay(Collision col){
		if(col.gameObject.tag == "Block"){
			Block tempBlock  = col.gameObject.GetComponent<Block>();

			switch (tempBlock.blockType) {
			case "Fire":
				fireCounter = debuffTime;
				var fem = fireEffect.emission;
				fem.enabled = true;
				break;
			case "Water":
				break;
			case "Bounce":
				break;
			case "Slow":
				slowCounter = debuffTime;
				var sem = slowEffect.emission;
				sem.enabled = true;
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

	void checkSideStatus(){
		bool isfrontSided = Physics.OverlapSphere (frontCheck.position, groundRadius, whatIsGround).Length!=0;
		bool isbackSided = Physics.OverlapSphere (backCheck.position, groundRadius, whatIsGround).Length!=0;

		isSided = isfrontSided || isbackSided;

		if (!isSided) {
			walljumpCounter = 3;
		}
	}


	void spawn(){
		gameObject.SetActive (true);
		currentHp = maxHp;
		animator.SetLayerWeight (2, 0);

		slowCounter = 0f;
		fireCounter = 0f;

		var sem = slowEffect.emission;
		var fem = fireEffect.emission;
		sem.enabled = false;
		fem.enabled = false;

		var gObj = GameObject.Find("Player" + assignedPlayer + "_spawn");

		rb.velocity = Vector3.zero;
		if (gObj){
			transform.position = gObj.transform.position;
			rb.velocity = Vector3.zero;
		}
		rb.isKinematic = false;
		isDead = false;
	}
	
	void die(){
		if (isDead) {
			return;
		}
		rb.velocity = Vector3.zero;
		animator.SetLayerWeight (2, 1);
		audioSource.clip = audioClips[2];
		audioSource.Play();

		animator.SetTrigger("isDead");
		Invoke("spawn", 3);
		isDead = true;
		rb.isKinematic = true;
	}


	public void enableGroundCheck(){
		groundCheckPause = false;
	}

	public void doDamage(float dmg){
		currentHp -= dmg;
	
		if (currentHp <= 0) {
			die ();
		}
	}



}
