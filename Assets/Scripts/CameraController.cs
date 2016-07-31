using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject[] allPlayer;

	private static float MINIMUMDISTANCE = 13f;

	private float xMin;
	private float xMax;
	private float yMin;
	private float yMax;

    public float fovXFactor;
	public float fovYFactor;


	private float zPos = -25f;

	// Use this for initialization
	void Start () {
		GameController.cam = GetComponent<Camera> ();
		allPlayer = GameObject.FindGameObjectsWithTag("Player");
		float fov = GetComponent<Camera> ().fieldOfView;
		float aspect = GetComponent<Camera> ().aspect;





		fovXFactor = 1 / (2 * Mathf.Tan (fov / 2));
		fovYFactor = aspect * 1 / ( 2 *Mathf.Tan (fov / 2));
	}
	
	// Update is called once per frame
	void Update () {
		calculateContainingRectangle ();

		float d;

		float xDistance = (xMax - xMin) * fovXFactor;
		float yDistance = (yMax - yMin) * fovYFactor;


		if (GameController.center.activeRotation != EnvironmentController.Rotations.NOROTATION) {
			d = Mathf.Max (xDistance, yDistance, MINIMUMDISTANCE + 5);
		} else {
			d = Mathf.Max (xDistance, yDistance, MINIMUMDISTANCE);
		}

		float speedFactor = 1.8f;

		Vector3 distance = transform.position - new Vector3 ((xMin + xMax) / 2, (yMin + yMax) / 2, -d);
		if (distance.magnitude > 9) {
			speedFactor = 0.5f;
		}

		print (distance.magnitude);


		transform.position = Vector3.Lerp (transform.position, new Vector3 ((xMin + xMax) / 2, (yMin + yMax) / 2, -d), Time.deltaTime / speedFactor);
	}

	void calculateContainingRectangle(){
		xMin = 20;
		xMax = -10;
		yMin = 10;
		yMax = 0;
		foreach (HumanPlayer player in GameController.playerList) {
			float x = player.character.transform.position.x;

			xMin = Mathf.Min (x, xMin);
			xMax = Mathf.Max (x, xMax);

			float y = player.character.transform.position.y;

			yMin = Mathf.Min (y, yMin);
			yMax = Mathf.Max (y, yMax);
		}
	}
}
