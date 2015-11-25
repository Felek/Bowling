using UnityEngine;
using System.Collections;

public class CollideKula : MonoBehaviour {
    public GameObject KulaPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Plane")
        {
            Instantiate(KulaPrefab, new Vector3(0f, 11.4f, -0.2f), new Quaternion(0,0,0,0));
            Destroy(gameObject);
        }
    }
}
