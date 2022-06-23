using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    /*
    [SerializeField]
    private GameObject startPoint;

    [SerializeField]
    private GameObject endPoint;

    private Vector3 initialEndPointPos;

    void Start()
    {
        initialEndPointPos = endPoint.transform.localPosition;
    }

    public void OnSpawn(GameObject spawn)
    {

        endPoint.transform.localPosition = initialEndPointPos;

        Vector3 direction = startPoint.transform.position - endPoint.transform.position;
        
        if (spawn.GetComponent<Movement>() != null) { 
            spawn.GetComponent<Movement>().Direction = direction;
        }

    }*/



    [SerializeField]
    private GameObject startPoint;

    [SerializeField]
    private GameObject endPoint;

    private Vector3 initialEndPointPos;

    void Start()
    {
        initialEndPointPos = endPoint.transform.localPosition;
    }

    public void OnSpawn(GameObject spawn)
    {

        ResetEndPoint();

        Vector3 direction = startPoint.transform.position - endPoint.transform.position;

        if (spawn.GetComponent<Movement>() != null)
        {
            spawn.GetComponent<Movement>().Direction = direction;
        }

    }

    public void ResetEndPoint()
    {
        endPoint.transform.localPosition = initialEndPointPos;
    }






}
