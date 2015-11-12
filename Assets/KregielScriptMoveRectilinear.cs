using UnityEngine;
using System.Collections;

public class KregielScriptMoveRectilinear : MonoBehaviour 
{	
	float x = 0.0f, y = -0.1f;
	bool move = false;
	float time = 0.0f;
	int kierunek = 1;

	/// <summary>
	/// Start skryptu - brak operacji
	/// </summary>
	void Start () 
	{		
	}
	
	/// <summary>
	/// Update - po naciśnięciu F10 określone obiekty (kręgle) będą poruszać się ruchem jednostajnym po kwadracie
	/// </summary>
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.F10))
			move = !move;
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
