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

	public BaseCharacter character;
	public float aimhp;
	public GameObject uiMarkerPrefab;
	public UiMarker uiMarker; 
	RectTransform rectUiMarker;
	public HealthbarScript hpbar;




	// Use this for initialization
	void Start () {
		uiMarker = Instantiate (uiMarkerPrefab).GetComponent<UiMarker>();
		uiMarker.transform.parent = GameObject.Find ("Canvas").transform;
		uiMarker.color = player.teamNumber - 1;
		uiMarker.setText (player.nameHuman);
		rectUiMarker = uiMarker.GetComponent<RectTransform> ();
		hpbar.character = character;

	}
	
	// Update is called once per frame
	void Update () {
	

		rectUiMarker.position = GameController.cam.WorldToScreenPoint (character.transform.position);
		hpbar.refresh ();



		if(refresh){

		
		


			playerName.text = player.nameHuman;
			killCounter.text = "" + player.kills;
			deathCounter.text ="" +  player.deaths;


			killCounter.text = "" + player.kills;
			deathCounter.text ="" +  player.deaths;




		}
		
	}


	public void repaint(){
		refresh = true;
		aimhp=character.currentHp/character.maxHp ;
	}

	public void resetHealthbar(){
		hpbar.reset ();
	}

	public void grayOut(){

		//for(int i=0;i<transform.GetChildCount;i++){




		//}
	}


}
