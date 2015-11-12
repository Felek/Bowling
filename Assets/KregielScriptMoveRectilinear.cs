using UnityEngine;
using System.Collections;

public class KregielScriptMoveRectilinear : MonoBehaviour {
	
	float x = 0.0f, y = -0.1f;
	bool move = false;
	float time = 0.0f;
	int kierunek = 1;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.F10))
			move = true;
		if (move) 
		{
			time += Time.deltaTime;
			if (time > 0.5f)
			{
				time = 0.0f;
				float bufor;
				bufor = y;
				y = x * kierunek;
				x = bufor;
				kierunek = -kierunek;
			}
			transform.Translate (x, 0.0f, y);
		}
	}
}
