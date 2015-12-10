using UnityEngine;
using System.Collections;

public class DartBehaviour : MonoBehaviour {

	bool dartActivated = false;
	float strength = 0f;
	Rigidbody rb;
    float angle;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody>();
		rb.useGravity = false;
	}
	
	// Update is called once per frame
	void Update () {	
		if (dartActivated) {
			strength += Time.deltaTime * 3000f;
		}

         //if (Input.GetAxis("Mouse ScrollWheel") &gt; 0) // forward
         //{
         //    Camera.main.orthographicSize++;
         //}
         //if (Input.GetAxis("Mouse ScrollWheel") &lt; 0) // back
         //{
         //    Camera.main.orthographicSize--;
         //}
        float d = Input.GetAxis("Mouse ScrollWheel");
        if (d > 0f)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        else if (d < 0f)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
        angle += d;
        transform.Rotate(new Vector3(1,0,0), angle);
	}
	
	void OnMouseDown()
	{        
		dartActivated = true;
	}

	void OnMouseUp()
	{        
		rb.useGravity = true;
		rb.AddForce ((Vector3.forward + Vector3.up / 3) * strength, ForceMode.Acceleration);
		dartActivated = false;
		strength = 0f;
	}
}
