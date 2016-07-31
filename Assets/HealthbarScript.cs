using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class HealthbarScript : MonoBehaviour {
	public GameObject hpbarFragment;
	public List<RectTransform> fragmentTransforms;
	public int offsetx;
	public float stretcher;


	bool changed;

	float aimHp;
	float uiHp=1;
	public BaseCharacter character;
	// Use this for initialization
	void Start () {
		fragmentTransforms = new List<RectTransform> ();
		for(int i=0;i<10;i++){

		

			fragmentTransforms.Add(GameObject.Instantiate (hpbarFragment).GetComponent<RectTransform>());
			fragmentTransforms [i].localScale *= stretcher;
			fragmentTransforms [i].transform.parent = transform;
			fragmentTransforms [i].position = transform.position;
			Vector3 tempVec=fragmentTransforms[i].position;
			tempVec.x += i * offsetx -fragmentTransforms [i].rect.width ;
			fragmentTransforms [i].position = tempVec;

		}
	}


	
	// Update is called once per frame
	void Update () {
		
		if(aimHp<uiHp){
			
			uiHp -= Time.deltaTime;

			if (fragmentTransforms [(int)(uiHp*10)].gameObject.activeSelf) {
				
				//fragmentTransforms [(int)(uiHp * 10)].gameObject.SetActive (false);
				fragmentTransforms [(int)(uiHp*10)].GetComponent<Animator> ().enabled=true;
				fragmentTransforms [(int)(uiHp * 10)].GetComponent<Animator> ().Play ("delete");

			}
		}
		/*if(aimhp>hpb){
		if(aimhp<m.GetFloat("_Health")){
			m.SetFloat("_Health",m.GetFloat("_Health")-Time.deltaTime );//material.setColor("_OutlineColor", Color.red);
		}
		if(aimhp>m.GetFloat("_Health")){
			m.SetFloat("_Health",m.GetFloat("_Health")+Time.deltaTime );//material.setColor("_OutlineColor", Color.red);
		}
		if(aimhp==m.GetFloat("_Health")){
			refresh = false;
		}
		}*/
	}

		public	void refresh(){
		aimHp=character.currentHp/character.maxHp ;

	}

	public	void reset(){
		//aimHp=character.currentHp/character.maxHp ;
		uiHp=1;
		for (int i = 0; i < fragmentTransforms.Count; i++) {
			
			fragmentTransforms [i].transform.GetChild (0).gameObject.SetActive (true);
			fragmentTransforms [i].GetComponent<Animator> ().Play ("respawnHealthbar");
		//fragmentTransforms[i].GetComponent<Animator> ().enabled=false;
			//fragmentTransforms [i].transform.GetChild (0).gameObject.SetActive (true);
			//Color c = fragmentTransforms [i].transform.GetChild (0).GetComponent<Image> ().color;
			//c.a = 1;
			//fragmentTransforms [i].transform.GetChild (0).GetComponent<Image>().color=c;
			//fragmentTransforms [i].transform.GetChild (0).GetComponent<Animator> ().;

		}

	}
}
