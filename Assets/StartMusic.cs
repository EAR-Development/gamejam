using UnityEngine;
using System.Collections;

public class StartMusic : MonoBehaviour {

	public AudioSource source;
	public AudioClip clip;
	public float counter = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(counter > 0){
			counter -= Time.deltaTime;
		}
		else if(counter <= 0){
			if(!source.isPlaying){
				source.clip = clip;
				source.loop = true;
				source.Play();
			}
		}
	}
}
