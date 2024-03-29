﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public static int totalPlayers{ get; set;}	
	public static List<HumanPlayer> playerList{get; set;}
	public static List<HumanPlayer> winnerTeam{get; set;}
	public static Camera cam{get; set;}
	public static EnvironmentController center{get; set;}
	public static int maxLife{get; set;}
	public static int playersLeft{get; set;}
	public static int TeamsLeft{get; set;}
	public static int teams{get; set;}
	public static scoreboard board{get; set;}
	public static AudioSource sceneSound{get; set;}
	public static int winningTeamNr = -1;
	public static string gameMode{get; set;}


	// Use this for initialization
	void Start () {
	


	}
	

	
	public static void reportLost(HumanPlayer p){
		List<HumanPlayer> winnerTeam= new List<HumanPlayer>();
		List<int> countedTeams= new List<int>();
		
		if(gameMode == "Koth"){
			

				board.gameObject.SetActive (true);
				//board.setTeamBar (countedTeams[0], winnerTeam);
				board.setTeamBar (winningTeamNr, winnerTeam);
						


			


			
		}
		else {
			playersLeft = 0;
			
			
			for(int i=0;i< playerList.Count;i++){
				//allPlayers.Add(playerList[i]);
				if(playerList[i].lifesLeft!=0){			
					if(!countedTeams.Contains(playerList[i].teamNumber)){
						countedTeams.Add (playerList[i].teamNumber);

					}
					playersLeft++;
				}

			}
	
			if(countedTeams.Count==1) {

			
				for(int i=0;i< playerList.Count;i++){
					if(playerList[i].lifesLeft!=0){
						if(playerList[i].teamNumber==countedTeams[0]){
							
							winnerTeam.Add (playerList[i]);
							Debug.Log("winners: "+playerList[i]);

						}
					
					}

				}

				board.gameObject.SetActive (true);
				//board.setTeamBar (countedTeams[0], winnerTeam);
				board.setTeamBar (countedTeams[0], winnerTeam);
						


			}
		}
		
		
	}
	
	// Update is called once per frame
	void Update () {
		int playersLeft=0;


		if(playersLeft==1){
			
		}
		

	}


}
