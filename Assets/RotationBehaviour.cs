using UnityEngine;
using System.Collections;

public class RotationBehaviour : MonoBehaviour
{
    SilaBehaviour strengthBar;
    float timecount;
    float stoptime = 0;
    float starttime;
    byte color = 0;
    int kierunek = 1;
    bool strengthBarStopped = false;

    public bool Stopped { get; set; }
    public float Rotation { get; set; }

    // Use this for initialization
    void Start()
    {
        starttime = Time.time;
        Stopped = false;
        strengthBar = (SilaBehaviour)FindObjectOfType(typeof(SilaBehaviour));
    }

    // Update is called once per frame
    void Update()
    {
        // jeśli siła została wybrana (spacja) i gracz ponownie użyje spacji zmiana kolorów paska zostanie zatrzymana a wartość rotacji określona
        if (strengthBarStopped && Input.GetKeyDown(KeyCode.Space))
        {
            Stopped = true;
            // rotacja przyjmuje wartości <-0.5, 0.5> (kierunek rotacji w prawo lub w lewo)
            Rotation = timecount - (float)0.5;
        }
        if (strengthBar.Stopped)
            strengthBarStopped = true;

        if (!Stopped)
        {
            timecount = Time.time * (kierunek) - stoptime * (kierunek) - starttime;
            if (timecount > 1 || timecount < 0)
            {
                stoptime += timecount * 2;
                kierunek = -kierunek;
            }
            // zmiana koloru paska rotacji
            gameObject.GetComponent<Renderer>().material.color = new Color(1, timecount, (float)0.02, 1);
        }
    }
}
