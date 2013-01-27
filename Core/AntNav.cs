using UnityEngine;
using System.Collections;

public class AntNav : MonoBehaviour {
	
	float btnSize=100f;
	public GUISkin guiskin;
	
	GameObject goSparkle;
	
	static bool called=false;
	
	void Start(){
		goSparkle = GameObject.Find ("MagicCarpet").transform.Find ("Sparkle Rising").gameObject;	
		goSparkle.SetActiveRecursively(false);
	}
	
	void OnGUI(){
		GUI.skin = guiskin;
		if(GUI.Button(new Rect(0,0,Screen.width,btnSize),"")){
			rigidbody.AddForce (transform.forward*5f,ForceMode.Impulse);
		}
		if(GUI.Button(new Rect(0,Screen.height-btnSize,Screen.width,btnSize),"")){
			rigidbody.AddForce (-transform.forward*5f,ForceMode.Impulse);
		}
		if(GUI.Button(new Rect(0,0,btnSize,Screen.height),"")){
			rigidbody.AddForce (-transform.right*5f,ForceMode.Impulse);
		}
		if(GUI.Button(new Rect(Screen.width-btnSize,0,btnSize,Screen.height),"")){
			rigidbody.AddForce (transform.right*5f,ForceMode.Impulse);
		}		
	}
	
	public void KillIt(){
		if(goSparkle!=null&&!called){
			GameObject g = GameObject.Instantiate(goSparkle,transform.position,Quaternion.identity) as GameObject;
			g.SetActiveRecursively(true);
			called=true;
		}
		
		ScoreKeeper.Dead ();
		
		Destroy(gameObject);
	}	
	
}
