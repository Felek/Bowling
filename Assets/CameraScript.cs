using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	Camera cameraStart;
	Camera cameraKula;
	Camera cameraBok;
	Camera[] cameras;
	// Use this for initialization
	void Start ()
    {
		cameras = Camera.allCameras; 
		cameras[0].enabled = true;
		cameras[1].enabled = false;
		cameras[2].enabled = false;
		//Camera.allCameras [2].enabled = false;
        //cameraBok = cameras [0];
        //cameraKula = cameras [1];
        //cameraStart = cameras [2];
        //	cameraStart = GameObject.Find("Start Camera");
        //	cameraKula = GameObject.Find("Kula Camera");
        //	cameraBok = GameObject.Find("Bok Camera");
        //cameraStart.SetActive(false);

        //cameraStart.enabled = true;
        //cameraBok.enabled = false;
        //cameraKula.enabled = false;
        //cameraKula.SetActive(false);
        //cameraBok.SetActive(true);
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
