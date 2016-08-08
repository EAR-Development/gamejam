using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class StartGame : MonoBehaviour {


	public SelectorBox[] boxes;
	public GameObject playerPrefab;
	public GameObject[] playableCharacters;
	public Slider slider;
	public Slider hpSlider;
	public Toggle toggle;
	public static int playerNr = 1;
	public int playerCount = 0;
	public int playersReady = 0;
	public bool changingScene = false;
	public Button startButton;

	public AudioClip clip;
	// Use this for initialization
	void Start () {
	
		GameController.playerList = new List<HumanPlayer> ();

	}
	
	// Update is called once per frame
	void Update () {
		if(playerNr <= 4){		
			if(Input.GetButtonUp("Player" + playerNr + "_start_ctrlr")){			
				AssignController();
			}				
		}
		
		if((Input.GetButtonUp("Player" + 1 + "_start_ctrlr")) && (boxes[0].selection != 0)){
			CheckControllerStart();
		}
		
	}
	
	public void AssignController(){
		Debug.Log("controller joined: "+playerNr);
		
		
		if(boxes[0].selection != 0){
			boxes[playerNr].toggle.isOn = true;
			boxes[playerNr].assignedController = playerNr;
			playerNr++;
		}	
		else if(boxes[playerNr-1].selection == 0){
			boxes[playerNr-1].toggle.isOn = true;
			boxes[playerNr-1].assignedController = playerNr;
			playerNr++;
		}	
		
	}
	
	public void CheckControllerStart(){
		
		for(int i = 0; i < boxes.Length; i++){
			if(boxes[i].assignedController > 0){
				playerCount++;
				Debug.Log("playerCount: "+playerCount);
				if(boxes[i].controllerReady){
					playersReady++;
					Debug.Log("playersReady: "+playersReady);
				}				
				else {	
					Debug.Log("player not Ready: "+playersReady);
				}
			}
		}
		
		if(playerCount == playersReady){
			startButton.onClick.Invoke();
			/*
			if(!changingScene){
				changeScene(1);
				Debug.Log("change scene");
				changingScene = true;
			}
			*/
		}
		playersReady = 0;
		playerCount = 0;
	}

	public void changeScene(int scene){
		if(GameController.gameMode == "Original"){
			scene = 1;
		}
		else if(GameController.gameMode == "Brawl"){
			scene = 2;
		}
		else if(GameController.gameMode == "Koth"){
			scene = 3;
		}
		else if(GameController.gameMode == "CTF"){
			scene = 4;
		}
		
		if(boxes[0].selection > 0){
			GameController.sceneSound.clip = clip;
			GameController.sceneSound.Play();
			int playerCount=0;
			for(int i=0;i<boxes.Length;i++){

				if(boxes[i].selection > 0){
					HumanPlayer p = Instantiate (playerPrefab).GetComponent<HumanPlayer>();
					p.teamNumber = boxes [i].teamNumber;
					p.lifesLeft = (int)slider.value;
					p.maxHp = (int)hpSlider.value;
					GameController.playerList.Add (p);					
					p.nameHuman = boxes [i].nameInput.text;
					playerCount++;
					p.playerNumber = playerCount;
					p.characterPrefab=playableCharacters[boxes[i].selection -1];
					if(boxes[i].toggle.isOn){
						p.useController = true;
						HumanPlayer.controllerNr = playerCount;
						//boxes[i].toggle.isOn = false;
					}
					/*
					if(boxes[i].toggle.isOn){
						p.characterPrefab.GetComponent<BaseCharacter>().useController = true;
						Debug.Log("use controller");
					}
					*/
				}
				
				GameController.totalPlayers = playerCount;

			}
			StartCoroutine ( LoadNewScene(scene) );

		}
	}

	IEnumerator LoadNewScene(int scene) {



	AsyncOperation async = Application.LoadLevelAsync(scene);

		while (!async.isDone) {
			yield return null;
		}

	}
}
