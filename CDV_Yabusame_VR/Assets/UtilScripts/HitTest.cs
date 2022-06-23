using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HitTest : MonoBehaviour
{

    public UnityEvent OnHit;

    [SerializeField]
    public Animation hitAnimation;


    public void Hit()
    {
        
            hitAnimation.Play();
            Destroy(gameObject, hitAnimation.clip.length);

            OnHit?.Invoke();

    }
}
