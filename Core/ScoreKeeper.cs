using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {
	
	//static int intBlobs;
	static float timeElapsed;
	
	public GUIText guitext;
	
	public static GUIText guiGameOver;
	
	public static bool gameover=false;
	static AntNav an;
	static GameObject goAnt;
	
	void Start(){
		guiGameOver = GameObject.Find ("guiGameOver").guiText;
		guiGameOver.active=false;
		goAnt = GameObject.Find ("MagicCarpet").gameObject;
		an = goAnt.GetComponent<AntNav>();
	}
	
	// Use this for initialization
	public static void Dead () {
		guiGameOver.gameObject.active=true;
		gameover=true;
		//an.KillIt();
	}
	
	// Update is called once per frame
	void Update () {
		if(gameover)
			return;
		
		timeElapsed+=Time.deltaTime;
		guitext.text = "Time Alive: "+Mathf2.Round10th (timeElapsed).ToString() + "s";
	}
}
