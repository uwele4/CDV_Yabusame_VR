using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZickZackV : MonoBehaviour
{
    float TimeCounter = 0;
    float hochoderrunter = 2;
    bool nachoben = true;
    bool nachunten = false;

    void Update()
    {
        TimeCounter += Time.deltaTime;
        if (TimeCounter % 6 >= 3)
        {
            nachunten = true; nachoben = false;
        }
        if (TimeCounter % 6 < 3)
        {
            nachoben = true; nachunten = false;
        }
        if (nachoben)
        {
            transform.position = new Vector3(hochoderrunter * Mathf.PingPong(Time.time, 1), 2 * TimeCounter % 6, transform.position.z);
        }
        if (nachunten)
        {
            transform.position = new Vector3(hochoderrunter * Mathf.PingPong(Time.time, 1), -2 * TimeCounter % 6 + 6, transform.position.z);
        }
    }
}
