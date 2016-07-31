using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject[] allPlayer;

	private static float MINIMUMDISTANCE = 18f;

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

		Debug.Log (aspect);



		fovXFactor = 1 / (2 * Mathf.Tan (fov / 2));
		fovYFactor = aspect * 1 / ( 2 *Mathf.Tan (fov / 2));
	}
	
	// Update is called once per frame
	void Update () {
		calculateContainingRectangle ();

		float d = Mathf.Max (xMax - xMin, yMax - yMin, 20);

		float xDistance = (xMax - xMin) * fovXFactor;
		float yDistance = (yMax - yMin) * fovYFactor;

		d = Mathf.Max (xDistance, yDistance, MINIMUMDISTANCE);

		transform.position = Vector3.Lerp (transform.position, new Vector3 ((xMin + xMax) / 2, (yMin + yMax) / 2, -d), Time.deltaTime / 1.8f);
	}

	void calculateContainingRectangle(){
		xMin = 20;
		xMax = -10;
		yMin = 10;
		yMax = 0;
		foreach (GameObject player in allPlayer) {
			float x = player.transform.position.x;

			xMin = Mathf.Min (x, xMin);
			xMax = Mathf.Max (x, xMax);

			float y = player.transform.position.y;

			yMin = Mathf.Min (y, yMin);
			yMax = Mathf.Max (y, yMax);
		}
	}
}
