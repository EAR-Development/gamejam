using UnityEngine;
using System.Collections;

public class particleKiller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("selfDestruction", 2f);
	}

	void selfDestruction(){
		GameObject.Destroy (this.gameObject);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
