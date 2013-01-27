using UnityEngine;
using System.Collections;

public class SinusCurveModifier : MonoBehaviour {

// This script is placed in public domain. The author takes no responsibility for any possible harm.

float scale = 1f;
float speed = 1f;
Vector3[] baseHeight;
	
public Vector3 dir = Vector3.zero;	
	
Transform tAnt;
	
Vector3 targetAntPos;
	
float timeElapsed=0f;
	
GameObject goSparkle;
	
public Camera cam;
	
	PlaySounds ps;
	
void Start(){
//	tAnt = GameObject.Find ("MagicCarpet").transform;	
	goSparkle = transform.Find ("Sparkle Rising").gameObject; goSparkle.SetActiveRecursively(false);
		
	scale = Random.Range (0.25f,0.5f);
	speed = Random.Range (1.05f,1.95f);
		
	ps = GameObject.Find ("GameObject").GetComponent<PlaySounds>();
}


void Update () {timeElapsed+=Time.deltaTime;
		

		
	Mesh mesh = GetComponent<MeshFilter>().mesh;
	
	if (baseHeight == null)
		baseHeight = mesh.vertices;
	
	var vertices = new Vector3[baseHeight.Length];
	for (var i=0;i<vertices.Length;i++)
	{
		var vertex = baseHeight[i];
		/*var q = Mathf.Sin(Time.time * speed+ baseHeight[i].x + baseHeight[i].y + baseHeight[i].z) * scale;
			vertex.y += q*q;
		vertices[i] = vertex;*/
		//vertices[i] = vertex + mesh.normals[i] * Mathf.Sin(Time.time * speed + Random.Range (0.5f,0.9f))*scale*0.1f*Random.Range (0,2);
			var q = Mathf.Sin(Time.time * speed + baseHeight[i].x + baseHeight[i].y + baseHeight[i].z ) * scale ;
			vertices[i] = vertex;
			vertices[i].y = vertex.y + q*q*2;
	}
	mesh.vertices = vertices;
	mesh.RecalculateNormals();
		
	WanderUp();
}
	
	void WanderUp(){
		/*if(ScoreKeeper.gameover)
			return;*/
		if(transform.position.y>100f){
			// direct towards ant
			//print (transform.position);
			targetAntPos = new Vector3(0,0.001f,0); //tAnt.position;
			MoveTowards (Vector3.zero);
		}else{
			if(targetAntPos==null||targetAntPos==Vector3.zero){
				Vector3 z;
				if(dir!=Vector3.zero)
				z=transform.position+new Vector3(0,1f,-1f);
				else z=Vector3.zero;
				MoveTowards (z);
			}else {
				//print (targetAntPos);
				MoveTowards(targetAntPos);
			}
		}
	}
	
	void MoveTowards(Vector3 v){
		Vector3 q = v - transform.position;
		transform.position += q.normalized * 0.5f;	
	}
	
	void OnTriggerEnter(Collider col){
		string name = col.name;//print (col.name);
		
		if(name=="Human Heart"){
			ExplodeSelf();
		}else if(name=="Plane"){
			
		}
	}
	
	void ExplodeSelf(){
		if(timeElapsed>5f){
			GameObject g  =  GameObject.Instantiate(goSparkle,transform.position,Quaternion.identity) as GameObject;
			g.SetActiveRecursively(true);
			Destroy (gameObject);	
		}
	}
	
}
