using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject[] allPlayer;

	private float xMin;
	private float xMax;
	private float yMin;
	private float yMax;

	// Use this for initialization
	void Start () {
		allPlayer = GameObject.FindGameObjectsWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		calculateContainingRectangle ();
		Debug.Log (xMin + ":" + xMax);
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
