using UnityEngine;
using System.Collections;

public class Block_Hp : MonoBehaviour {

	public float healTimer = 23;
	public bool healReady = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(healTimer > 0){
			healTimer -= Time.deltaTime;
		}
		else if(healTimer <= 0){
			healReady = true;
		}
	}
	
	void OnCollisionEnter(Collision col ){
		if(col.gameObject.tag == "Player"){
			if(col.gameObject.GetComponent<BaseCharacter>()){
				if(col.gameObject.GetComponent<BaseCharacter>().characterClass != "ProfM"){
					if(healReady){
						BaseCharacter baseCharacter = col.gameObject.GetComponent<BaseCharacter>();			
						//baseCharacter.lastHit = this.transform.root.GetComponent<BaseCharacter>().player;
						baseCharacter.Heal (15.0f);	
						healTimer = 23;
						GameObject.Instantiate (baseCharacter.SpawnEffect, col.transform.position, col.transform.rotation);
						healReady = false;
					}
				}
			}
		}
	}
}
