using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NachRechts : MonoBehaviour
{
    float TimeCounter = 0;

    // Update is called once per frame
    void Update()
    {
        TimeCounter += Time.deltaTime;
        float x = 1;
        float y = Mathf.Sin(5 * TimeCounter);
        float z = 0;
        Vector3 direction = new Vector3(x * 2, y, z);
        transform.position += direction * Time.deltaTime;
    }

    public void Remove()
    {
        Debug.Log("Hit");
        Destroy(this);
    }
}
