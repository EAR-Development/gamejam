using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectorBox : MonoBehaviour {

	public int selection=0;
	public int max=4;
	public int min=0;
	public Sprite[] sprites;
	public Image SelectionImage;
	public Text nameInput;
	public int teamNumber=1;
	public Image arrowLeft;
	public Image arrowRight;
	public Sprite[] arrows;
	public Sprite[] teamBarSprites;
	public Image teamBar;
	public int maxTeams;
	public Toggle toggle;
	public int assignedController = 0;
	public bool controllerReady = false;

	// Use this for initialization
	void Start () {
		arrowLeft.sprite=arrows[teamNumber-1];
		arrowRight.sprite=arrows[teamNumber-1];
		teamBar.sprite=teamBarSprites[teamNumber-1];

	}
	
	// Update is called once per frame
	void Update () {
	
		
	
		if(Input.GetButtonDown("Player" + assignedController + "_action_ctrlr")){
			//playerNr++;
			down();
			//Debug.Log("controller start"+assignedController);
			//toggle.isOn = true;
		}
		if(Input.GetButtonDown("Player" + assignedController + "_jump_ctrlr")){
			//playerNr++;
			up();
			//Debug.Log("controller start"+assignedController);
			//toggle.isOn = true;
		}
		
		if((Input.GetButton("Player" + assignedController + "_start_ctrlr")) ){			
			controllerReady = true;
		}
		else {
			controllerReady = false;
		}
		
	}

	public void switchTeam(){

		if (teamNumber < maxTeams) {
			teamNumber++;
		} else {
			teamNumber = 1;
		}

		arrowLeft.sprite=arrows[teamNumber-1];
		arrowRight.sprite=arrows[teamNumber-1];
		teamBar.sprite=teamBarSprites[teamNumber-1];

	}

	public void up(){
		if(selection<max){
			selection++;
			SelectionImage.sprite=sprites[selection];
			GameController.sceneSound.Play();
		}
	}

	public void down(){
		if(selection>min){
			selection--;
			SelectionImage.sprite=sprites[selection];
			GameController.sceneSound.Play();
		}
	

	}
}
