using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderVisualizer : MonoBehaviour {

	public Text t;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		t.text = "" + GetComponent<Slider> ().value;
	}


}
