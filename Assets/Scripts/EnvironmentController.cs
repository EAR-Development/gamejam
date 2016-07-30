using UnityEngine;
using System.Collections;

public class EnvironmentController : MonoBehaviour {
		
	public Vector3 targetAngle = new Vector3(0f, 0f, 0f);
	private Vector3 currentAngle;
	public Vector3 tempVec;
	public Block[] aBlocks;

	public void Start()	{
		currentAngle = transform.eulerAngles;
		
	}
	
	public void Update(){		
		if(currentAngle != targetAngle){
			Rotate(targetAngle);
		}		
		
		if(Input.GetButtonDown("RotateLeft")){				
			tempVec +=  new Vector3(0f, 0f, 90f);
			SetTargetAngle(tempVec);
		}
		
		if(Input.GetButtonDown("RotateRight")){				
			tempVec -=  new Vector3(0f, 0f, 90f);
			SetTargetAngle(tempVec);
		}
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
