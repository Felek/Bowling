using UnityEngine;
using System.Collections;

public class SilaBehaviour : MonoBehaviour
{
    float timecount;
    float stoptime = 0;
    float starttime;
    byte color = 0;
    int kierunek = 1;

    public bool Stopped { get; set; }
    public float Strength { get; set; }

    // Use this for initialization
    void Start()
    {
        starttime = Time.time;
        Stopped = false;
    }

    // Update is called once per frame
    void Update()
    {
        // naciśnięcie spacji powoduje zatrzymanie zmiany koloru i ustalenie wartości siły
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Stopped = true;
            Strength = 1 - timecount;
        }

        if (!Stopped)
        {
            timecount = Time.time * (kierunek) - stoptime * (kierunek) - starttime;
            if (timecount >= 1.0 || timecount <= 0.0)
            {
                stoptime += timecount * 2;
                kierunek = -kierunek;
            }
            // zmiana koloru paska siły
            gameObject.GetComponent<Renderer>().material.color = new Color(1, timecount, (float)0.02, 1);
        }
    }
}
