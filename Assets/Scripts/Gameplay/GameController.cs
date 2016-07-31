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





	// Use this for initialization
	void Start () {
	
	}

	public static void reportLost(){
		playersLeft = 0;
		int tleft;
		List<int> countedTeams= new List<int>();
		for(int i=0;i< playerList.Count;i++){
			if(playerList[i].lifesLeft!=0){
				if(!countedTeams.Contains(playerList[i].teamNumber)){
					countedTeams.Add (playerList[i].teamNumber);

				}
				playersLeft++;
			}

		}

		if(countedTeams.Count==1) {
			print ("WIIIIIIIIN");
		}

	}
	
	// Update is called once per frame
	void Update () {
		int playersLeft=0;


		if(playersLeft==1){
			
		}

	}


}
