using UnityEngine;
using System.Collections;

public class CollideColorChange : MonoBehaviour {

    bool setBlue = false;
    public int minimumCollidesToDestroy=10, maximumCollidesToDestroy=20;
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
    }

    void OnTriggerEnter()
    {
        collidesCount++;
        if (collidesCount >= countOfCollidesToDestroy)
        {
            Destroy(gameObject);
        }
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
