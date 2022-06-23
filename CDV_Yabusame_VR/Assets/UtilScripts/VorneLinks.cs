using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VorneLinks : MonoBehaviour
{

    float TimeCounter = 0;

    // Update is called once per frame
    void Update()
    {
        TimeCounter += Time.deltaTime;
        float x = -2;
        float y = Mathf.Sin(5 * TimeCounter);
        float z = -2;
        Vector3 direction = new Vector3(x, y, z);
        transform.position += direction * Time.deltaTime;

    }

    public void Remove()
    {
        Debug.Log("Removed");
        Destroy(this);
    }
}
