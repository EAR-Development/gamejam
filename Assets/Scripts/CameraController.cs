using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject[] allPlayer;

	// Use this for initialization
	void Start () {
		allPlayer = GameObject.FindGameObjectsWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
