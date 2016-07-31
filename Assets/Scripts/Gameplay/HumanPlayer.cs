using UnityEngine;
using System.Collections;

public class HumanPlayer : MonoBehaviour {


	public string nameHuman;
	public int kills;
	public int deaths;
	public GameObject playerInfoUi;
	public int playerNumber;
	UIUpdater uiUpdater;
	bool instantiateUI=false;
	public BaseCharacter character;
	public GameObject characterPrefab;
	public int teamNumber;
	public int lifesLeft;

	//character char
	// Use this for initialization

	void Awake() {
		DontDestroyOnLoad(this);
	}

	void OnLevelWasLoaded(){
		
		instantiateUI = true;

	} 



	void Start () {
		
	


	}

	// Update is called once per frame
	void Update () {
		if(instantiateUI){
			character=	Instantiate (characterPrefab).GetComponent<BaseCharacter>();//TODO spawnpunkte?
			character.player = this;
			character.assignedPlayer=playerNumber;
			character.setUpLayers ();

			character.transform.position = GameObject.Find ("Player" + playerNumber + "_spawn").transform.position;
		kills = 0;
		deaths = 0;
		GameObject g =Instantiate (playerInfoUi);
		g.transform.parent = GameObject.Find ("Canvas").transform;

			g.GetComponent<RectTransform> ().position = new Vector3 ((Screen.width) / (GameController.totalPlayers +1) * playerNumber, Screen.height / 10, 0);


		uiUpdater = g.GetComponent<UIUpdater> ();
			uiUpdater.character = character;
		uiUpdater.player = this;
			instantiateUI = false;
			uiUpdater.repaint();
		}

	}

	public void repaint(){
		uiUpdater.repaint ();
	}
	public void resetHealthBar(){

		uiUpdater.resetHealthbar ();
	}

	//public void
}
