using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour 
{
	Camera[] cameras = new Camera[3];

	/// <summary>
	/// Start skryptu - wypełnienie tablicy kamer
	/// </summary>
	void Start ()
    {
		cameras = Camera.allCameras; 
    }

	/// <summary>
	/// Update - zmiana kamer po naciśnięciu F1, F2, F3 poprzez ustawianie ich parametru enabled.
	/// </summary>
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.F1))
		 {
			cameras[0].enabled = true;
			cameras[1].enabled = false;
			cameras[2].enabled = false;
    	 }
        if (Input.GetKeyDown(KeyCode.F2))
        {
			cameras[1].enabled = true;
			cameras[0].enabled = false;
			cameras[2].enabled = false;
        }
		if (Input.GetKeyDown(KeyCode.F3))
		{
			cameras[2].enabled = true;
			cameras[0].enabled = false;
			cameras[1].enabled = false;
		}
    }
}
