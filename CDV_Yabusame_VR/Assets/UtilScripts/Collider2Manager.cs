using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider2Manager : MonoBehaviour
{
    public GameObject collider;
    // Start is called before the first frame update
    void Start()
    {
        collider.GetComponent<Falldown>().enabled = false;
    }

    public void FallDown()
    {
        collider.GetComponent<Falldown>().enabled = true;
    }

}
