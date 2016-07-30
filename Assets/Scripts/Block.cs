using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	public string blockType;
	public bool isVisible;

	[Header("Materials")]

	public Material normalMaterial;
	public Material slowMaterial;
	public Material fireMaterial;

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
		var rand = Random.Range (0f, 1f);
		if (rand >= 0.8f) {
			ChangeBlockType("Slow");
		}else if (rand >= 0.6f) {
			ChangeBlockType("Fire");
		}else{
			ChangeBlockType("Normal");
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
			break;
		case "Fire":
			rend.sharedMaterial = fireMaterial;
			break;
		case "Normal":
			rend.sharedMaterial = normalMaterial;
			break;
		}
	}
	
	
}
