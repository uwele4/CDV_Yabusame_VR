using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rechtslinks : MonoBehaviour
{
    [SerializeField, Tooltip("Geschwindigkeit bzw. Ausschlag")]
    private float schwung = 0.0f;
    float TimeCounter = 0;
    
    // Update is called once per frame
    void Update()
    {
        TimeCounter += Time.deltaTime;
        float x = Mathf.Cos(TimeCounter);
        float y = 0; // Mathf.Sin(TimeCounter);
        float z = 0;
        Vector3 direction = new Vector3(x, y, z);
        transform.position += schwung * direction * Time.deltaTime;
    }


    public void Remove()
    {

        Debug.Log("Hit");
        Destroy(this);
    }
}
