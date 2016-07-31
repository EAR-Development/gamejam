using UnityEngine;
using System.Collections;

public class audioInstantiate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameController.sceneSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
}
