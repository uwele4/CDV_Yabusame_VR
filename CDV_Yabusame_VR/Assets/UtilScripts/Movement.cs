using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField, Tooltip("The movement direction")]
    private Vector3 direction = new Vector3(0,0,0);
    public Vector3 Direction
    {
        set { direction = value; }
    }

    [SerializeField, Tooltip("The speed in px/second")]
    private float speed = 0.0f;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += speed * direction * Time.deltaTime;
    }

    public void Remove()
    {
        Debug.Log("Hit");
        Destroy(this);
    }

}
