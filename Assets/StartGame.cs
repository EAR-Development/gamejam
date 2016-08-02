﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class StartGame : MonoBehaviour {


	public SelectorBox[] boxes;
	public GameObject playerPrefab;
	public GameObject[] playableCharacters;
	public Slider slider;
	public Toggle toggle;

	public AudioClip clip;
	// Use this for initialization
	void Start () {
	
		GameController.playerList = new List<HumanPlayer> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void changeScene(int scene){
		GameController.sceneSound.clip = clip;
		GameController.sceneSound.Play();
		int playerCount=0;
		for(int i=0;i<boxes.Length;i++){

			if(boxes[i].selection!=0){
				HumanPlayer p = Instantiate (playerPrefab).GetComponent<HumanPlayer>();
				p.teamNumber = boxes [i].teamNumber;
				p.lifesLeft = (int)slider.value;
				GameController.playerList.Add (p);
				p.nameHuman = boxes [i].nameInput.text;
				playerCount++;
				p.playerNumber = playerCount;
				p.characterPrefab=playableCharacters[boxes[i].selection -1];
				if(boxes[i].toggle.isOn){
					p.useController = true;
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

	IEnumerator LoadNewScene(int scene) {



	AsyncOperation async = Application.LoadLevelAsync(scene);

		while (!async.isDone) {
			yield return null;
		}

	}
}
