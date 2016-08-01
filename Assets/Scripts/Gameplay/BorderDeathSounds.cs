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
		
			audioSource.clip = col.GetComponent<BaseCharacter>().audioClips[2];
			
			
			
			audioSource.Play();
		}
	}
}
