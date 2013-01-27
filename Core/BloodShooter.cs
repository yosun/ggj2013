using UnityEngine;
using System.Collections;

public class BloodShooter : MonoBehaviour {
	
	GameObject goBloodule;
	
	float totalTimeBetween=0f;
	float nextTimeInterval=1.37f;
	
	void Start(){
		Init ();	
	}
	
	void Init () {
		goBloodule = GameObject.Find ("Bloodule");
	}
	
	void Update () {
		if(goBloodule!=null){
			// test blood spouts (will be controlled by sound)
			if(totalTimeBetween>nextTimeInterval){
				totalTimeBetween=0f;
				nextTimeInterval = Random.Range (1.37f,10f);
				
				SpoutBloodule();
			}
			totalTimeBetween+=Time.deltaTime;
		}else Init();
	}
	
	void SpoutBloodule(){
			
	}
}
