using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{

    float TimeCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 startpoint = new Vector3(-35, 2, 19);
        transform.position = startpoint;  
    }

    // Update is called once per frame
    void Update()
    {
        TimeCounter += Time.deltaTime;
        float x = 0b10; 
        float y = Mathf.Sin(5 * TimeCounter);
        float z = -0x1;
        Vector3 direction = new Vector3(x * 2, y, z);
        transform.position += direction * Time.deltaTime;

    }

    public void Remove()
    {
        Debug.Log("Removed");
        Destroy(this);
    }
}
