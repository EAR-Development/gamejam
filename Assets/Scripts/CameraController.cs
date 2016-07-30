using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject[] allPlayer;

	private float xMin;
	private float xMax;
	private float yMin;
	private float yMax;

    public float fovFactor;

	private float zPos = -25f;

	// Use this for initialization
	void Start () {
		allPlayer = GameObject.FindGameObjectsWithTag("Player");
		float fov = GetComponent<Camera> ().fieldOfView;
		fovFactor = 1 / (2 * Mathf.Tan (fov / 2));
	}
	
	// Update is called once per frame
	void Update () {
		calculateContainingRectangle ();

		float d = Mathf.Max (xMax - xMin, yMax - yMin, 20);

		Debug.Log (d);

		transform.position = Vector3.Lerp (transform.position, new Vector3 ((xMin + xMax) / 2, (yMin + yMax) / 2, -d*fovFactor), Time.deltaTime / 2);
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
