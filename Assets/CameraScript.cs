using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	Camera cameraStart;
	Camera cameraKula;
	Camera cameraBok;
	Camera[] cameras = new Camera[3];

	// Use this for initialization
	void Start ()
    {
		cameras = Camera.allCameras; 
    }

    // Update is called once per frame
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
