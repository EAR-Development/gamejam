using UnityEngine;
using System.Collections;

public class EnvironmentController : MonoBehaviour {
		
	public Vector3 targetAngle = new Vector3(0f, 0f, 0f);
	private Vector3 currentAngle;
	public Vector3 tempVec;
	public GameObject[] aBlocks;

	[Header("Timer")]
	public float rotateTimer = 10f;
	public float blockTimer = 5f;

	[Header("Status")]
	public float rotateCounter = 0f;
	public float blockCounter = 0f;

	public void Start()	{
		currentAngle = transform.eulerAngles;

		aBlocks = GameObject.FindGameObjectsWithTag("Block");
	}
	
	public void Update(){		
		if(currentAngle != targetAngle){
			Rotate(targetAngle);
		}		
		
		if(Input.GetButtonDown("RotateLeft")){				
			rotateRight ();
		}
		
		if(Input.GetButtonDown("RotateRight")){				
			rotateRight ();
		}

		rotateCounter += Time.deltaTime;
		blockCounter += Time.deltaTime;

		if(rotateCounter > rotateTimer){
			if (Random.Range (0f, 1f) < 0.5f) {
				rotateLeft ();
			} else {
				rotateRight ();
			}

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
		tempVec +=  new Vector3(0f, 0f, 90f);
		SetTargetAngle(tempVec);
	}
	void rotateRight(){
		tempVec -=  new Vector3(0f, 0f, 90f);
		SetTargetAngle(tempVec);
	}

	public void Rotate(Vector3 targetAngle) 	{
		//public Vector3 targetAngle = new Vector3(0f, 0f, 90f);
		currentAngle = new Vector3(
		Mathf.LerpAngle(currentAngle.x, targetAngle.x, Time.deltaTime),
		Mathf.LerpAngle(currentAngle.y, targetAngle.y, Time.deltaTime),
		Mathf.LerpAngle(currentAngle.z, targetAngle.z, Time.deltaTime));

		transform.eulerAngles = currentAngle;
	}
	
	public void SetTargetAngle(Vector3 newTarget){
		targetAngle = newTarget;
	}
	
	
}
