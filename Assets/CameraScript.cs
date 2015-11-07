using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	Camera cameraStart;
	Camera cameraKula;
	Camera cameraBok;
	Camera[3] cameras;
	// Use this for initialization
	void Start () {

		Camera.GetAllCameras (cameras);
		cameraBok = cameras [0];
		cameraKula = cameras [1];
		cameraStart = cameras [2];
	//	cameraStart = GameObject.Find("Start Camera");
	//	cameraKula = GameObject.Find("Kula Camera");
	//	cameraBok = GameObject.Find("Bok Camera");
		//cameraStart.SetActive(false);
		cameraBok.enabled = false;
		cameraKula.enabled = false;
		cameraStart.enabled = true;
		//cameraKula.SetActive(false);
		//cameraBok.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
    	 if (Input.GetKeyDown(KeyCode.F))
		 {
			//cameraStart.SetActive(false);
		//	cameraBok.SetActive(false);
		//	cameraKula.SetActive(true);
			
			cameraBok.enabled = false;
			cameraKula.enabled = true;
			cameraStart.enabled = false;
    	 }
	}
}
