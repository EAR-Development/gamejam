using UnityEngine;
using System.Collections;

public class EnvironmentController : MonoBehaviour {
		
	public Vector3 targetAngle = new Vector3(0f, 0f, 0f);
	private Vector3 currentAngle;
	public Vector3 tempVec;
	public GameObject[] aBlocks;

	public bool shouldRotate = true;
	public float RotationFactor = 0.5f;

	[Header("Timer")]
	public float rotateTimer = 10f;
	public float blockTimer = 3f;

	[Header("Status")]
	public float rotateCounter = 0f;
	public float blockCounter = 0f;

	public enum Rotations {
		PRELEFT, LEFT, PRERIGHT, RIGHT, NOROTATION 
	}
	public float preRotationCounter = 0f;
	public float rotationStartDelay = 3.0f;

	public Animator animator;

	public Rotations activeRotation = Rotations.NOROTATION;

	public void Start()	{
		currentAngle = transform.eulerAngles;

		aBlocks = GameObject.FindGameObjectsWithTag("Block");

		if(GetComponent<Animator>()){
			animator = GetComponent<Animator>();
		}

		GameController.center = this;
	}
	
	public void Update(){		
		if(currentAngle != targetAngle){
			Rotate(targetAngle);
		}		
		
		if(Input.GetButtonDown("RotateLeft")){				
			rotateLeft ();
		}
		
		if(Input.GetButtonDown("RotateRight")){				
			rotateRight ();
		}

		rotateCounter += Time.deltaTime;
		blockCounter += Time.deltaTime;

		Vector3 deltaAngle = currentAngle - targetAngle;

		if (activeRotation == Rotations.PRELEFT || activeRotation == Rotations.PRERIGHT) {
			if (Mathf.Abs(deltaAngle.z) < 1) {
				if (activeRotation == Rotations.PRELEFT){
					activeRotation = Rotations.LEFT;
					rotationDone = 0;
					tempVec +=  new Vector3(0f, 0f, 95f);
					SetTargetAngle(tempVec);
				}else{
					activeRotation = Rotations.RIGHT;
					rotationDone = 0;
					tempVec -=  new Vector3(0f, 0f, 95f);
					SetTargetAngle(tempVec);
				}
			}
		}



		if (Mathf.Abs(deltaAngle.z) < 15 && (activeRotation == Rotations.LEFT || activeRotation == Rotations.RIGHT)) {
			activeRotation = Rotations.NOROTATION;
		}


		if(rotateCounter > (rotateTimer + rotationStartDelay) && shouldRotate){
			if (Random.Range (0f, 1f) < 0.5f) {
				rotateLeft ();
			} else {
				rotateRight ();
			}
			rotationStartDelay = 0;
			rotateCounter = 0f;
		}
			
		if(blockCounter > blockTimer){
			foreach (GameObject block  in aBlocks) {
				Block b = block.GetComponent<Block>();
				b.setRandomType ();
			}

			blockCounter = 0f;
		}
	}

	void rotateLeft(){
		activeRotation = Rotations.PRELEFT;
		rotateCounter = 0f;
		rotationDone = 0;
		tempVec -=  new Vector3(0f, 0f, 5f);
		SetTargetAngle(tempVec);
	}
	void rotateRight(){
		activeRotation = Rotations.PRERIGHT;
		rotateCounter = 0f;
		rotationDone = 0;
		tempVec +=  new Vector3(0f, 0f, 5f);
		SetTargetAngle(tempVec);
	}

	float rotationDone = 0;

	public void Rotate(Vector3 targetAngle){

		rotationDone += Time.deltaTime * RotationFactor;

		currentAngle = new Vector3(
			currentAngle.x,
			currentAngle.y,
			Mathf.LerpAngle(currentAngle.z, targetAngle.z, rotationDone)
		);

		transform.eulerAngles = currentAngle;
	}
	
	public void SetTargetAngle(Vector3 newTarget){
		targetAngle = newTarget;
	}
	
	
}
