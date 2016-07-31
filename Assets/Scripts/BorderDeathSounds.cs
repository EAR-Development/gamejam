using UnityEngine;
using System.Collections;

public class BorderDeathSounds : MonoBehaviour {

	public AudioSource audioSource;
	public AudioClip[] audioClips;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
		
			if(col.gameObject.name == "Prism"){
				audioSource.clip = audioClips[0];
			}
			else if(col.gameObject.name == "ThomasTomato"){
				audioSource.clip = audioClips[1];
			}
			else if(col.gameObject.name == "3FacePlus1"){
				audioSource.clip = audioClips[2];
			}
			else if(col.gameObject.name == "ProfM"){
				audioSource.clip = audioClips[3];
			}
			else if(col.gameObject.name == "DestructionDetlef"){
				audioSource.clip = audioClips[4];
			}
			else if(col.gameObject.name == "NewChar"){
				audioSource.clip = audioClips[5];
			}
			
			audioSource.Play();
		}
	}
}
