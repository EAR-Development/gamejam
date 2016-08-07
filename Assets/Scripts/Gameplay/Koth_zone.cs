using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Koth_zone : MonoBehaviour {


	public List<GameObject> playersInZone;
	public bool sameTeam = true;
	public bool gameRunning = true;
	public int scoreToWin = 32;
	public int teamNr = 0;
	public float[] teamScore;
	public float zoneCheckInterval = 0.5f;
	public TextMesh[] texts;

	// Use this for initialization
	void Start () {
		playersInZone = new List<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(gameRunning){
			if(playersInZone.Count == 1){
				teamNr = playersInZone[0].GetComponent<BaseCharacter>().player.teamNumber;
				if(teamScore[teamNr-1] < scoreToWin ){
					teamScore[teamNr-1] += Time.deltaTime;
				}
				else {
					Debug.Log("victory team: "+(teamNr));
					GameController.winningTeamNr = teamNr;
					GameController.reportLost(playersInZone[0].GetComponent<BaseCharacter>().player);
					gameRunning = false;
				}
			}
			else if(playersInZone.Count > 1){
				if(sameTeam){
					if(teamScore[teamNr-1] < scoreToWin ){
						teamScore[teamNr-1] += Time.deltaTime * 1.5f;
					}
					else {
						Debug.Log("victory team: "+(teamNr));
						GameController.winningTeamNr = teamNr;
						GameController.reportLost(playersInZone[0].GetComponent<BaseCharacter>().player);
						gameRunning = false;
					}
				}
			}
			
			if(zoneCheckInterval > 0){
				zoneCheckInterval -= Time.deltaTime;
			}
			else {
				zoneCheckInterval = 0.5f;
				CheckTeams();
			}
		}
		
		for(int i = 0; i < texts.Length; i++){
			texts[i].text = ((int)teamScore[i]).ToString();
		}
	}
	
	public void CheckTeams(){
		if(playersInZone.Count == 1){
			teamNr = playersInZone[0].GetComponent<BaseCharacter>().player.teamNumber;
		}
		else if(playersInZone.Count > 1){
			for(int i = 1; i < playersInZone.Count; i++){			
				if(playersInZone[i].layer  != playersInZone[i-1].layer ){
					sameTeam = false;	
					teamNr = 0;
					break;
				}
				else {
					sameTeam = true;
					teamNr = playersInZone[i].GetComponent<BaseCharacter>().player.teamNumber;
				}
				Debug.Log("player "+i+" b: "+sameTeam);
			}
		}
	}
	
	void OnTriggerStay(Collider col ){
		if(col.gameObject.tag == "Player"){
		
		}
	}
	
	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
			playersInZone.Add(col.gameObject);
			//CheckTeams();
			Debug.Log("player entered koth zone");
		}
	}
	
	void OnTriggerExit(Collider col){
		if(col.gameObject.tag == "Player"){
			playersInZone.Remove(col.gameObject);
			//CheckTeams();
			Debug.Log("player left koth zone");
		}
	}
	
}
