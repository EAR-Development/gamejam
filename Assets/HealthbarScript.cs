using UnityEngine;
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

		for (int i = 0; i < fragmentTransforms.Count; i++) {
			print ("asdfasd");
			fragmentTransforms[i].gameObject.SetActive (true);
			fragmentTransforms[i].GetComponent<Animator> ().enabled=false;
		}

	}
}
