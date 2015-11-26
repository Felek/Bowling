using UnityEngine;
using System.Collections;

public class CollideKula : MonoBehaviour {
    public GameObject KulaPrefab;
    public int minimumCollidesToDestroy = 2, maximumCollidesToDestroy = 8;
    private int countOfCollidesToDestroy;
    private int collidesCount = 0;

    // Use this for initialization
    void Start () {
        System.Random rand = new System.Random();
        countOfCollidesToDestroy = rand.Next(minimumCollidesToDestroy, maximumCollidesToDestroy);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        collidesCount++;
        if (collidesCount >= countOfCollidesToDestroy)
        {
            collidesCount = 0;
            Destroy(gameObject);
            Instantiate(KulaPrefab, new Vector3(0f, 11.4f, -0.2f), new Quaternion(0, 0, 0, 0));
        }
        if (collision.gameObject.name == "Plane")
        {
            collidesCount = 0;
            Instantiate(KulaPrefab, new Vector3(0f, 11.4f, -0.2f), new Quaternion(0,0,0,0));
            Destroy(gameObject);
        }
    }
}
