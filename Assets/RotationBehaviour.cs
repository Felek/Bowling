using UnityEngine;
using System.Collections;

public class RotationBehaviour : MonoBehaviour
{
    SilaBehaviour strengthBar;
    float timecount;
    float stoptime = 0;
    float starttime;
    int kierunek = 1;
    bool strengthBarStopped = false;

	/// <summary>
	/// Określa czy rotacja została ustalona czy nie <see cref="RotationBehaviour"/>.
	/// </summary>
	/// <value><c>true</c> rotacja ustalona; w przeciwnym wypadku rotacja nieustalona <c>false</c>.</value>
    public bool Stopped { get; set; }
	/// <summary>
	/// Określa rotację rzutu.
	/// </summary>
	/// <value>Rotacja rzutu.</value>
    public float Rotation { get; set; }

	/// <summary>
	/// Start skryptu - wyszukanie obiektu paska siły, inicjalizacja zmiennych
	/// </summary>
    void Start()
    {
        starttime = Time.time;
        Stopped = false;
        strengthBar = (SilaBehaviour)FindObjectOfType(typeof(SilaBehaviour));
    }

	/// <summary>
	/// Update - określenie rotacji rzutu - reakcja na klawisz spacja po określeniu siły rzutu - zatrzymanie wartości rotacji zależnej od aktualnego koloru paska siły (czerwony - rotacja w lewo, żółty - w prawo).
	/// </summary>
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
                kierunek *= -1;
            }
            // zmiana koloru paska rotacji
            gameObject.GetComponent<Renderer>().material.color = new Color(1, timecount, (float)0.02, 1);
        }
    }
}
