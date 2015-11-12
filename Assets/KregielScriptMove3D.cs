using UnityEngine;
using System.Collections;

public class KregielScriptMove3D : MonoBehaviour {
	
	private Transform target;
	float angle = 0;
	float speed = (2 * Mathf.PI) / 5;
	float radius = 0.04f;
	float x, y;
	bool move = false;
	
	/// <summary>
	/// Start skryptu - wyszukanie obiektu Kręgla
	/// </summary>
	void Start() 
	{
		target = GameObject.Find ("Kręgiel: Top (12)").transform;
	}
	
	/// <summary>
	/// Update - poruszanie obiektem po okręgu z kątem zmiennym sinusoidalnie (wielkie okręgi wolne, małe szybkie)
	/// </summary>
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.F12)) 
			move = !move;
		
		if (move)
		{
			speed += Mathf.Sin (Time.time) / 5;
			angle += speed * Time.deltaTime;
			x = Mathf.Cos (angle) * radius;
			y = Mathf.Sin (angle) * radius;
			target.transform.Translate (x, 0.0f, y);
			target.RotateAround(new Vector3(0.0f, 0.15f, 0.25f), 0.02f);
		}
	}
}
