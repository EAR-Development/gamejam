using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public static int totalPlayers{ get; set;}
	public static List<HumanPlayer> playerList{get; set;}
	public static Camera cam{get; set;}
	public static EnvironmentController center{get; set;}
	public static int maxLife{get; set;}
	public static int playersLeft{get; set;}
	public static int TeamsLeft{get; set;}
	public static int teams{get; set;}
	public static scoreboard board{get; set;}
	public static AudioSource sceneSound{get; set;}





	// Use this for initialization
	void Start () {
	


	}

	public static void reportLost(HumanPlayer p){


		playersLeft = 0;
		List<int> countedTeams= new List<int>();
		List<HumanPlayer> winnerTeam= new List<HumanPlayer>();
		for(int i=0;i< playerList.Count;i++){
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


					}
				
				}

			}

			board.gameObject.SetActive (true);
			board.setTeamBar (countedTeams [0], winnerTeam);

				


		}

	}
	
	// Update is called once per frame
	void Update () {
		int playersLeft=0;


		if(playersLeft==1){
			
		}

	}


}
