using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CallingManager : MonoBehaviour
{

    public UnityEvent ManagerCall;
    [SerializeField]

    // Start is called before the first frame update
    void Start()
    {
        ManagerCall?.Invoke();
    }

}
