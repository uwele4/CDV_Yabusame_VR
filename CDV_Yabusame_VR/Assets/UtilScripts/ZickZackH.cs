using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZickZackH : MonoBehaviour
{
    float TimeCounter = 0;
    float hochoderrunter = 2;
    bool nachrechts = true;
    bool nachlinks = false;

    void Update()
    {
        TimeCounter += Time.deltaTime;
        if (TimeCounter % 6 >= 3)
        {
            nachlinks = true; nachrechts = false;
        }
        if (TimeCounter % 6 < 3)
        {
            nachrechts = true; nachlinks = false;
        }
        if (nachrechts)
        {
            transform.position = new Vector3(2 * TimeCounter % 6 - 2, hochoderrunter * Mathf.PingPong(Time.time, 1), transform.position.z);
        }
        if (nachlinks)
        {
            transform.position = new Vector3(-2 * TimeCounter % 6 + 4, hochoderrunter * Mathf.PingPong(Time.time, 1), transform.position.z);
        }
    }
}

