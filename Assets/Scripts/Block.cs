using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	public string blockType;
	public bool isVisible;

	[Header("Materials")]

	public Material normalMaterial;
	public Material slowMaterial;
	public Material fireMaterial;
	public Material invisMaterial;
	public Material bounceMaterial;
	public PhysicMaterial bouncePhysicMaterial;

	public Renderer rend;
	
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		rend.enabled = true;

		setRandomType ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setRandomType(){
		if (blockType == "Normal") {
			var rand = Random.Range (0f, 1f);
			if (rand >= 0.99f) {
				ChangeBlockType ("Invis");
			} else if (rand >= 0.95f) {
				ChangeBlockType ("Slow");
			} else if (rand >= 0.93f) {
				ChangeBlockType ("Fire");
			} else if (rand >= 0.91f) {
				ChangeBlockType ("Bounce");
			}
		} else {
			var rand = Random.Range (0f, 1f);
			if (rand <= 0.4f) {
				ChangeBlockType ("Normal");
			}
		}
	}
	
	void ChangeVisibility(int visibility){
		if(visibility == 0){
			isVisible = false;
			GetComponent<MeshRenderer>().enabled = false;
			GetComponent<BoxCollider2D>().enabled = false;
		}
		else if(visibility == 1){
			isVisible = true;
			GetComponent<MeshRenderer>().enabled = true;
			GetComponent<BoxCollider2D>().enabled = true;
		}
	}

	void ChangeBlockType(string type){
		blockType = type;

		switch(type){
		case "Slow":
			rend.sharedMaterial = slowMaterial;
			transform.GetComponent<BoxCollider>().material = null;
			break;
		case "Fire":
			rend.sharedMaterial = fireMaterial;
			transform.GetComponent<BoxCollider>().material = null;
			break;
		case "Normal":
			rend.sharedMaterial = normalMaterial;
			transform.GetComponent<BoxCollider>().material = null;
			break;
		case "Invis":
			rend.sharedMaterial = invisMaterial;
			transform.GetComponent<BoxCollider>().material = null;
			break;
		case "Bounce":
			rend.sharedMaterial = bounceMaterial;
			transform.GetComponent<BoxCollider>().material = bouncePhysicMaterial;
			break;
		}
	}
	
	
}
