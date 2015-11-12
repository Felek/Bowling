using UnityEngine;
using System.Collections;

public class CollideColorChange : MonoBehaviour {

    bool setBlue = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



    void OnCollisionEnter(Collision collision)
    {
        
    }

    void OnTriggerEnter()
    {
        if (!setBlue)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        setBlue = !setBlue;
    }
}
