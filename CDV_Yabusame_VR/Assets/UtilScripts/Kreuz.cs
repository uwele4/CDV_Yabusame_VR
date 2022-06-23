using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kreuz : MonoBehaviour
{


    // Pruefwert, dass Bewegung nicht gerade erst begonnen hat, sondern schon bestimmte Strecke zurückgelegt wurde 
    bool bereitsumgekehrt = false;
    // Pruefwert, ob Bewegung hoch oder runter geht -> hoch, wenn hoch = 1, runter bei -1
    int hoch = 1;
    //Pruefwert, ob Bewegung nach rechts oder links geht -> rechts, wenn rechts = 1, links bei -1
    int rechts = 1;
    //Zeitzaehler
    float TimeCounter = 0;
    private Vector3 startpos;
    

    void Start()
    {
        //Startposition merken
        startpos = transform.position;
    } 

    void Update()
    {
        TimeCounter += Time.deltaTime;
        float x = hoch * Mathf.Cos(TimeCounter);
        float y = rechts * Mathf.Cos(TimeCounter);
        float z = 0;
        Vector3 direction = new Vector3(x, y, z);
        transform.position += 3 * direction * Time.deltaTime;

        //Erst ab bestimmter zurueckgelegter Strecke darf Richtungsschalter umegelegt werden
        if (Vector3.Distance(transform.position, startpos) > 4.0f)
        {
            //falls Strecke zurückgelegt: Umkehren
            bereitsumgekehrt = true;
            x = -x;
            y = -y; 
        }
        
        if (Vector3.Distance(transform.position, startpos) < 0.1f && bereitsumgekehrt)
        {
            bereitsumgekehrt = false;

            if (hoch == 1)
            {
                if(rechts == 1)
                {
                    //nach o.r. kommt o.l
                    rechts = -1;
                }
                else
                {
                    //nach o.l. kommt u.l.
                    hoch = -1;
                }
            }
            else 
            {
                if (rechts == -1)
                {
                    //nach u.l. kommt u.r.
                    rechts = 1;
                }
                else
                {
                    //nach u.r. kommt o.r.
                    hoch = 1;
                }
            
            }
        }
    }
}
