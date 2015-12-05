using UnityEngine;
using System.Collections;

public class DartBehaviour : MonoBehaviour {

	bool dartActivated = false;
	float strength = 0f;
	Rigidbody rb;

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
