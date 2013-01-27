using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {
	
	//static int intBlobs;
	static float timeElapsed;
	
	public GUIText guitext;
	public static GUIText guiNumHit;
	
	static int numHit=0;
	
	void Start(){
		guiNumHit = GameObject.Find ("GUINumHit").guiText;	
	}
	
	public static void HitBlob(){
		numHit++;
		guiNumHit.text = "Hit: "+numHit.ToString() + " bloodules";
	}
	
	// Update is called once per frame
	void Update () {
		
		timeElapsed+=Time.deltaTime;
		guitext.text = "Time Alive: "+Mathf2.Round10th (timeElapsed).ToString() + "s";
	}
}
