using UnityEngine;
using System.Collections;

public class RotationBehaviour : MonoBehaviour
{
    SilaBehaviour strengthBar;
    float time = 0.0f;
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
            Rotation = time - (float)0.5;
        }
        if (strengthBar.Stopped)
            strengthBarStopped = true;

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
            // zmiana koloru paska rotacji
            gameObject.GetComponent<Renderer>().material.color = new Color(1, time, (float)0.02, 1);
        }
    }
}
