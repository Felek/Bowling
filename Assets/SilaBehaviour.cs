using UnityEngine;
using System.Collections;

public class SilaBehaviour : MonoBehaviour
{
    int kierunek = 1;
    float time = 0.0f;

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
            Strength = 1 - time;
        }

        if (!Stopped)
        {
            if (kierunek == 1)
                time += Time.deltaTime;
            else
                time -= Time.deltaTime;

            if (time > 1 || time < 0)
            {
                kierunek = -kierunek;
                time += kierunek * Time.deltaTime;
            }

            // zmiana koloru paska siły
            gameObject.GetComponent<Renderer>().material.color = new Color(1, time, (float)0.02, 1);
        }
    }
}
