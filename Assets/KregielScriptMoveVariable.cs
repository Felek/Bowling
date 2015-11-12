using UnityEngine;
using System.Collections;

public class KregielScriptMoveVariable : MonoBehaviour {
	
	Transform target;
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
		target = GameObject.Find ("Kręgiel: Top (7)").transform;
	}

	/// <summary>
	/// Update - poruszanie obiektem po okręgu z kątem zmiennym sinusoidalnie (wielkie okręgi "wolne", małe "szybkie") po użyciu klawisza F11
	/// </summary>
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.F11)) 
			move = !move;

		if (move)
		{
			speed += Mathf.Sin (Time.time) / 5;
			angle += speed * Time.deltaTime;
			x = Mathf.Cos (angle) * radius;
			y = Mathf.Sin (angle) * radius;
			target.transform.Translate (x, 0.0f, y);
		}
	}
}
