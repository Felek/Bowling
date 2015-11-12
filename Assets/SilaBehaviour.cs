using UnityEngine;
using System.Collections;

public class SilaBehaviour : MonoBehaviour
{
    float timecount;
    float stoptime = 0;
    float starttime;
    int kierunek = 1;

	/// <summary>
	/// Określa czy siła została ustalona czy nie <see cref="SilaBehaviour"/>.
	/// </summary>
	/// <value><c>true</c> siła ustalona; w przeciwnym wypadku siła nieustalona <c>false</c>.</value>
    public bool Stopped { get; set; }
	/// <summary>
	/// Określa siłę rzutu.
	/// </summary>
	/// <value>Siła rzutu.</value>
    public float Strength { get; set; }

	/// <summary>
	/// Start skryptu - inicjalizacja zmiennych
	/// </summary>
    void Start()
    {
        starttime = Time.time;
        Stopped = false;
    }

	/// <summary>
	/// Update - określenie siły rzutu - reakcja na klawisz spacja - zatrzymanie wartości siły zależnej od aktualnego koloru paska siły (czerwony - mocny rzut, żółty - słaby).
	/// </summary>
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
