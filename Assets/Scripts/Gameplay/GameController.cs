using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public static int totalPlayers{ get; set;}
	public static List<HumanPlayer> playerList{get; set;}
	public static Camera cam{get; set;}
	public static EnvironmentController center{get; set;}
	public static int maxLife{get; set;}




	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		int playersLeft=0;

		for(int i=0;i< playerList.Count;i++){
			if(playerList[i].lifesLeft!=0){
				playersLeft++;
			}

		}

		if(playersLeft==1){
			
		}

	}


}
