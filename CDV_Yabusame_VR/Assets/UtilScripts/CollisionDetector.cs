using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class CollisionDetector : MonoBehaviour
{

    public UnityEvent onCollisionDetected;

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider);
        onCollisionDetected?.Invoke();
    }

}
