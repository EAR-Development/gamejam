using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void LoadMenu(){
		GameObject[] selBox = GameObject.FindGameObjectsWithTag("HumanPlayer");
		
		for(int i = 0; i < selBox.Length; i++){
			Destroy(selBox[i]);
		}
		Application.LoadLevel(0);

	}

	
}
