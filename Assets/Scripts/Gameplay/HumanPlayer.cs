using UnityEngine;
using System.Collections;

public class HumanPlayer : MonoBehaviour {


	public string nameHuman;
	public int kills;
	public int deaths;
	public GameObject playerInfoUi;
	public int playerNumber;
	 UIUpdater uiUpdater;

	//character char
	// Use this for initialization
	void Start () {
		GameController.totalPlayers = 1;
		kills = 0;
		deaths = 0;
		GameObject g =Instantiate (playerInfoUi);
		g.transform.parent = GameObject.Find ("Canvas").transform;
		g.GetComponent<RectTransform> ().position = new Vector3 ((Screen.width / 2) / GameController.totalPlayers * playerNumber,200,0);
		uiUpdater = g.GetComponent<UIUpdater> ();
		uiUpdater.player = this;


	}
	
	// Update is called once per frame
	void Update () {
	



	}
}
