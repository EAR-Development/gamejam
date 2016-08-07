using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	public string blockType;
	public bool isVisible;
	public bool dontChange = false;

	[Header("Materials")]

	public Color normalColor = Color.white;
	public Color slowColor = Color.yellow;
	public Color fireColor = Color.red;
	public Color invisColor = Color.magenta;
	public Color bounceColor = Color.green;
	public Color baitColor = Color.gray;
	public Color hpColor = Color.magenta;
	public Color kothColor = new Color(135,255,0,1);
	public PhysicMaterial bouncePhysicMaterial;

	public Renderer rend;
	
	// Use this for initialization
	void Start () {
		//rend = GetComponent<Renderer> ();
		//rend.enabled = true;
		setBlockColor(normalColor);
		

		setRandomType ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setRandomType(){
		if(!dontChange){
			if (blockType == "Normal") {
				var rand = Random.Range (0f, 1f);
				if (rand >= 0.97f) {
					ChangeBlockType ("Invis");
				} else if (rand >= 0.92f) {
					ChangeBlockType ("Slow");
				} else if (rand >= 0.89f) {
					ChangeBlockType ("Fire");
				} else if (rand >= 0.84f) {
					ChangeBlockType ("Bounce");
				}
			} 
			else {
				var rand = Random.Range (0f, 1f);
				if (rand <= 0.6f) {
					ChangeBlockType ("Normal");
				}
			}
		}
		else if(dontChange){
			if (blockType == "Normal") {
				ChangeBlockType ("Normal");
			}
			else if (blockType == "Invis") {
				ChangeBlockType ("Invis");
			}		
			else if (blockType == "Bounce") {
				ChangeBlockType ("Bounce");
			}
			 else if (blockType == "Slow") {
				ChangeBlockType ("Slow");
			}
			 else if (blockType == "Fire") {
				ChangeBlockType ("Fire");
			}
			else if (blockType == "Bait") {
				ChangeBlockType ("Bait");
			}
			else if (blockType == "HP") {
				ChangeBlockType ("HP");
			}
			else if (blockType == "Koth") {
				ChangeBlockType ("Koth");
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
			setBlockColor (slowColor);
			transform.GetComponent<BoxCollider>().material = null;
			break;
		case "Fire":
			setBlockColor (fireColor);
			transform.GetComponent<BoxCollider>().material = null;
			break;
		case "Normal":
			setBlockColor (normalColor);
			transform.GetComponent<BoxCollider>().material = null;
			break;
		case "Invis":
			setBlockColor (invisColor);
			transform.GetComponent<BoxCollider>().material = null;
			break;
		case "Bounce":
			setBlockColor (bounceColor);
			transform.GetComponent<BoxCollider>().material = bouncePhysicMaterial;
			break;				
		case "Bait":
			setBlockColor (baitColor);
			transform.GetComponent<BoxCollider>().material = null;
			//transform.GetComponent<BoxCollider>().material = bouncePhysicMaterial;
			break;		
		case "HP":
			setBlockColor (hpColor);
			transform.GetComponent<BoxCollider>().material = null;
			//transform.GetComponent<BoxCollider>().material = bouncePhysicMaterial;
			break;		
		case "Koth":
			setBlockColor (kothColor);
			transform.GetComponent<BoxCollider>().material = null;
			//transform.GetComponent<BoxCollider>().material = bouncePhysicMaterial;
			break;
		}
	}

	void setBlockColor(Color color){
		foreach (Transform child in transform) {
			if (child.name.StartsWith ("Cube")) {
				GameObject childObject = child.gameObject;

				Renderer renderer = childObject.GetComponent<Renderer>();
				Material mat = renderer.material;
				mat.SetColor ("_EmissionColor", color);
			}
		}
	}
	
	
}
