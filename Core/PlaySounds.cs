using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlaySounds : MonoBehaviour {
	
	public GameObject goAudio;
	Dictionary <string,GameObject> aud = new Dictionary<string,GameObject>();
	
	public Camera cam;
	
	void Start(){
		aud["C"] = goAudio.transform.Find ("AudioSource-C").gameObject;	
		aud["D"] = goAudio.transform.Find ("AudioSource-D").gameObject;
		aud["E"] = goAudio.transform.Find ("AudioSource-E").gameObject;	
		aud["F"] = goAudio.transform.Find ("AudioSource-F").gameObject;	
		aud["G"] = goAudio.transform.Find ("AudioSource-G").gameObject;	
		aud["A"] = goAudio.transform.Find ("AudioSource-A").gameObject;	
		aud["B"] = goAudio.transform.Find ("AudioSource-B").gameObject;	
	}
	
	public void PlaySound(string what){
		aud[what].GetComponent<AudioSource>().Play();
	}
	
	void Update(){
		/*if(Input.touchCount<1)
			return;*/
		
		
		Ray ray = cam.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast (ray,out hit,5000f)){
				string name = hit.transform.name;print (name);
				if(name=="Bloodule-red"){
					PlaySound ("C");
					ScoreKeeper.HitBlob();				
				}else if(name=="Bloodule-orange"){
					PlaySound ("D");
					ScoreKeeper.HitBlob();
				}else if(name=="Bloodule-yellow"){
					PlaySound ("E");
					ScoreKeeper.HitBlob();
				}else if(name=="Bloodule-green"){
					PlaySound ("F");
					ScoreKeeper.HitBlob();
				}else if(name=="Bloodule-blue"){
					PlaySound ("G");
					ScoreKeeper.HitBlob();				
				}else if(name=="Bloodule-black"){
					PlaySound ("A");
					ScoreKeeper.HitBlob();
				}else if(name=="Bloodule-violet"){
					PlaySound ("B");
					ScoreKeeper.HitBlob();
				}
		}		
	}
	
}
