using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionHandlerRider1 : MonoBehaviour
{
    public UnityEvent TargetHit;
    [SerializeField]

    public void OnHit()
    {
        TargetHit?.Invoke();
    }
}
