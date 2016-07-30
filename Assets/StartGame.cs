using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {


	public SelectorBox[] boxes;
	public GameObject playerPrefab;
	public GameObject[] playableCharacters;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void changeScene(int scene){

		int playerCount=0;
		for(int i=0;i<boxes.Length;i++){

			if(boxes[i].selection!=0){
				HumanPlayer p = Instantiate (playerPrefab).GetComponent<HumanPlayer>();
				p.nameHuman = boxes [i].nameInput.text;
				playerCount++;
				p.playerNumber = playerCount;
				p.characterPrefab=playableCharacters[boxes[i].selection -1];
			}
			GameController.totalPlayers = playerCount;

		}
		StartCoroutine ( LoadNewScene(scene) );

	}

	IEnumerator LoadNewScene(int scene) {



	AsyncOperation async = Application.LoadLevelAsync(scene);

		while (!async.isDone) {
			yield return null;
		}

	}
}
