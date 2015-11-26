using UnityEngine;
using System.Collections;

/// <summary>
/// Skrypt, w którym zaimplementowano ruch po łamanej
/// </summary>
public class KregielScriptMoveBroken : MonoBehaviour {
    
    bool move = false;
    float time = 0.0f;
    float x = 0.1f;
    float z = -0.1f;
    float h, deltah, oldh = 0;
    /// <summary>
    /// Gravity
    /// </summary>
    public float g = 30f;
    /// <summary>
    /// Initial velocity
    /// </summary>
    public float v0;
    float speedFactor = 0f;

    /// <summary>
    /// Start - następuje tu przypisanie wartości prędkości początkowej w zależności od ustawionej grawitacji tak, aby kręgiel skakał w rytm poruszania się po łamanej.
    /// </summary>
    void Start () {
	    v0 = 0.25f * g;
    }
	
	/// <summary>
    /// Update - po naciśnięciu F9 obiekt, do którego jest przypisany skrypt, będzie się poruszał torem łamanej z prędkością sinusoidalną, podskakując jednocześnie
    /// </summary>
	void Update () {
        if (Input.GetKeyDown(KeyCode.F9))
            move = !move;

        if (move)
        {
            h = v0 * time - g / 2 * time * time;
            deltah = h - oldh;
            oldh = h;

            speedFactor = Mathf.Sin(time*2*Mathf.PI);
            time += Time.deltaTime;
            if (time > 0.5)
            {
                time = 0f;
                x = -x;
            }
            transform.Translate(speedFactor*x, deltah, speedFactor*z);
        }
    }
}
