﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class scoreboard : MonoBehaviour {

	public Image teamBar;
	public Sprite[] sprites;
	public string[] teamNames;
	public Text playername1;
	public Text playername2;
	public Text playername3;
	public Text playername4;
	public Text teamName;
	public GameObject[] allPlayers;

	// Use this for initialization
	void Start () {
		GameController.board = this;
		gameObject.SetActive(false);
		allPlayers = GameObject.FindGameObjectsWithTag("HumanPlayer");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//public void setTeamBar(int winningteam, List<HumanPlayer> players, List<HumanPlayer> allPlayers){
	public void setTeamBar(int winningteam, List<HumanPlayer> players){
		teamName.text=teamNames[winningteam-1];
		teamBar.sprite=sprites[winningteam-1];
		/*
		for(int i=0;i< players.Count;i++){
			switch (i) {

			case 0:
				playername1.text = players [i].nameHuman + "  " + players [i].kills+ " / " + players [i].deaths;
				break;
			case 1:
				playername2.text = players [i].nameHuman + "  " + players [i].kills+ " / " + players [i].deaths;
				break;
			case 2:
				playername3.text = players [i].nameHuman + "  " + players [i].kills+ " / " + players [i].deaths;
				break;
			case 3:
				playername4.text = players [i].nameHuman + "  " + players [i].kills+ " / " + players [i].deaths;
				break;
			default:
				break;


			}
		}
		*/
		for(int i=0;i< allPlayers.Length;i++){
			switch (i) {
			
			case 0:
				playername1.text = allPlayers [i].GetComponent<HumanPlayer>().nameHuman + "  " + allPlayers [i].GetComponent<HumanPlayer>().kills+ " / " + allPlayers [i].GetComponent<HumanPlayer>().deaths;
				break;
			case 1:
				playername2.text = allPlayers [i].GetComponent<HumanPlayer>().nameHuman + "  " + allPlayers [i].GetComponent<HumanPlayer>().kills+ " / " + allPlayers [i].GetComponent<HumanPlayer>().deaths;
				break;
			case 2:
				playername3.text = allPlayers [i].GetComponent<HumanPlayer>().nameHuman + "  " + allPlayers [i].GetComponent<HumanPlayer>().kills+ " / " + allPlayers [i].GetComponent<HumanPlayer>().deaths;
				break;
			case 3:
				playername4.text = allPlayers [i].GetComponent<HumanPlayer>().nameHuman + "  " + allPlayers [i].GetComponent<HumanPlayer>().kills+ " / " + allPlayers [i].GetComponent<HumanPlayer>().deaths;
				break;
			default:
				break;
			}

		}

	}
}
