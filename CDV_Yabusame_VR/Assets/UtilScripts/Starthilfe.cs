using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;


public class Starthilfe : MonoBehaviour
{
    public UnityEvent Starthilfi;
    [SerializeField]


    public void DoIt()
    {
     Starthilfi?.Invoke();
    }

}
