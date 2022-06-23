using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falldown : MonoBehaviour
{

    float TimeCounter = 0;

    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        TimeCounter += Time.deltaTime;
        float x = 0;
        float y = -1;
        float z = 0;
        Vector3 direction = new Vector3(x, y, z);
        transform.position += direction * Time.deltaTime;
    }

    public void Remove()
    {
        Debug.Log("Hit");
        Destroy(this);
    }
}