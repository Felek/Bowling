using UnityEngine;
using System.Collections;

public class KulaBehaviour : MonoBehaviour
{
    Vector3 screenPoint;
    Vector3 offset;
    Rigidbody rb;
    Vector3 eulerAngleVelocity;
    float gravity = -9.8f;
    float timecount;
    float stoptime = 0;
    float starttime;
    byte color = 0;
    float rotationStrength = 5000;

    bool flag = false;

    SilaBehaviour strengthBar;              // pasek siły
    RotationBehaviour rotationBar;          // pasek rotacji - czerwony rotacja w lewo, żółty rotacja w prawo

    /// <summary>
    /// Start skryptu - inicjalizacja flag, pobranie obiektów
    /// </summary>
    void Start()
    {
        flag = false;
        starttime = Time.time;
        rb = gameObject.GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0f, -20.81f, 0f);
        strengthBar = (SilaBehaviour)FindObjectOfType(typeof(SilaBehaviour));
        rotationBar = (RotationBehaviour)FindObjectOfType(typeof(RotationBehaviour));
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            // siła powodująca rotację, przykładana po wykonaniu rzutu
            rb.AddTorque(0, rotationBar.Rotation * rotationStrength, rotationStrength * -rotationBar.Rotation);
            if (rotationStrength > 0)
                rotationStrength -= 100;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            // zmiana koloru kuli na czerwony po naciśnięciu 'R'
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            // zmiana koloru kuli na zielony po naciśnięciu 'G'
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            // zmiana koloru kuli na niebieski po naciśnięciu 'B'
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }

        timecount = Time.time - starttime - stoptime;
        if (timecount > 1)
        {
            stoptime += timecount;
            timecount = (float)0;
        }
        float x = timecount;
    }

    void OnMouseDown()
    {        
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    // przeciąganie kuli
    void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        transform.position = cursorPosition;
    }

    // zwolnienie przycisku myszy - przyłożenie odpowiednich sił w celu wykonania rzutu
    void OnMouseUp()
    {
        if (rotationBar.Stopped)
        {
            Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
            rb.AddForce(Vector3.forward * (strengthBar.Strength * 3000 + 500), ForceMode.Acceleration);
            rb.AddTorque(0, rotationBar.Rotation * rotationStrength, rotationStrength * -rotationBar.Rotation);
            flag = true;
        }
    }
}
