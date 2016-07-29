using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour {
	public Image characterImage;
	public Image healthBar;
	public Text killCounter;
	public Text deathCounter;
	public Text playerName;
	public bool refresh;
	public HumanPlayer player;
	public Material m;




	// Use this for initialization
	void Start () {
	
		healthBar.material.EnableKeyword("_Health");
		m = Instantiate (healthBar.material);
		healthBar.material = m;

		playerName.text = player.nameHuman;
		killCounter.text = "" + player.kills;
		deathCounter.text ="" +  player.deaths;
	
			
	}
	
	// Update is called once per frame
	void Update () {
	
		if(refresh){
			killCounter.text = "" + player.kills;
			deathCounter.text ="" +  player.deaths;

		}

	}


	public void repaint(){
		refresh = true;
	}




}
