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
	public BaseCharacter character;
	public float aimhp;




	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
	
		if(refresh){

			healthBar.material.EnableKeyword("_Health");
			m = Instantiate (healthBar.material);
			healthBar.material = m;


			playerName.text = player.nameHuman;
			killCounter.text = "" + player.kills;
			deathCounter.text ="" +  player.deaths;


			killCounter.text = "" + player.kills;
			deathCounter.text ="" +  player.deaths;

				if(aimhp<m.GetFloat("_Health")){
					m.SetFloat("_Health",m.GetFloat("_Health")-Time.deltaTime );//material.setColor("_OutlineColor", Color.red);
				}
				if(aimhp>m.GetFloat("_Health")){
					m.SetFloat("_Health",m.GetFloat("_Health")+Time.deltaTime );//material.setColor("_OutlineColor", Color.red);
				}
				if(aimhp==m.GetFloat("_Health")){
					refresh = false;
				}


		}

	}


	public void repaint(){
		refresh = true;
		aimhp=character.currentHp/character.maxHp ;
	}




}
