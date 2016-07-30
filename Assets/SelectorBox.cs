using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectorBox : MonoBehaviour {

	public int selection=0;
	public int max=4;
	public int min=0;
	public Sprite[] sprites;
	public Image SelectionImage;
	public Text nameInput;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		


	}

	public void up(){
		if(selection<max){
			selection++;
			SelectionImage.sprite=sprites[selection];
		}
	}

	public void down(){
		if(selection>min){
			selection--;
			SelectionImage.sprite=sprites[selection];
		}
	

	}
}
