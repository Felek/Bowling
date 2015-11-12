using UnityEngine;
using System.Collections;

public class KregielScriptMoveVariable : MonoBehaviour {
	
	private Transform target;
	float angle = 0;
	float speed = (2 * Mathf.PI) / 5;
	float radius = 0.04f;
	float x, y;

	void Start() 
	{
		target = GameObject.Find ("Kręgiel: Top (7)").transform; FindObjectOfType(typeof(KregielScriptMoveVariable));   
	}

	void Update()
	{
		speed += Mathf.Sin (Time.time) / 5;
		angle += speed*Time.deltaTime;
		x = Mathf.Cos(angle) * radius;
		y = Mathf.Sin(angle) * radius;
		target.transform.Translate (x, y, 0.0f);
	}
}
