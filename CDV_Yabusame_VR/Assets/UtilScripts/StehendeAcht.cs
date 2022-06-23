using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StehendeAcht: MonoBehaviour
{
    //[SerializeField, Tooltip("Geschwindigkeit bzw. Ausschlag")]
    //private float schwung = 0.0f;


    public Vector3 startPos;
    //Wertschalter, der Bewegungsrichtung festlegt
    float hochoderrunter;
    /* Pruefwert, dass der Kreis nicht gerade erst begonnen hat, 
     sondern schon Halbkreisstrecke zurückgelegt wurde */
    bool half;
    //Zeitzaehler
    float TimeCounter = 0;

    private void Start()
    {
        //Startposition merken
        startPos = transform.position; 
        //nach oben beginnen
        hochoderrunter = 1;
        half = false;
    }

    void Update()
    {
        TimeCounter += Time.deltaTime;
        float x = Mathf.Cos(TimeCounter);
        float y = Mathf.Sin(TimeCounter);
        float z = 0;
        Vector3 direction = new Vector3(x, hochoderrunter * y, z);

        transform.position += 3 * direction * Time.deltaTime;
        
        //Erst ab bestimmter zurueckgelegter Strecke darf Richtungsschalter umegelegt werden
        if (Vector3.Distance(transform.position, startPos) > 4.0f)
        {
            half = true;
        }
        
        if (Vector3.Distance(transform.position, startPos) < 0.3f && half)
        {
            //sobald ein Kreis geschafft: Bewegungsrichtungsschalter "umlegen"
            hochoderrunter = -1 * hochoderrunter;
            //"Refraktaerperiode" bis zu bestimmter geschaffter Strecke aktivieren
            half = false;
        }
    }

    public void Remove()
    {
        Debug.Log("Hit");
        Destroy(this);
    }
}