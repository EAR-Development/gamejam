using UnityEngine;
using System.Collections;

public class CTF_capzone : MonoBehaviour {
	
	public CTF_Flag flag;
	public int teamNr ;

	void Start () {
		flag = GameObject.FindGameObjectWithTag("Flag").GetComponent<CTF_Flag>();
	}

	void Update () {

	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Flag"){
			if(flag.teamNr == teamNr){
				if(flag.pickedUp == true){
					if(flag.captured == false){
						flag.CaptureFlag();
						flag.captured = true;
						Debug.Log("flag captured!");
					}
				}
			}
		}
	}
}
