using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UiMarker : MonoBehaviour {

	public Sprite[] arrowSprites;
	public Image arrow1;
	public Image arrow2;
	public Image arrow3;
	public Text playerName;


	public int color;

	// Use this for initialization
	void Start () {
		arrow1.sprite=arrowSprites[color];
		arrow2.sprite=arrowSprites[color];
		arrow3.sprite=arrowSprites[color];

	}

	public void setText(string s){
		playerName.text = s;
	}
	public void setColor(int c){
		color = c;
	}
	
	// Update is called once per frame
	void Update () {
	


	}
}
