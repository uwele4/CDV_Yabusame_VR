using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionHandler : MonoBehaviour
{
    public UnityEvent TargetHit;
    [SerializeField]
    private Animation hitAnimation;

    public void OnHit()
    {
        hitAnimation.Play();
        // Play SFX
        // ParticleEffect
        gameObject.transform.Find("Glitter").gameObject.SetActive(true);
        Debug.Log("ObHit aufgerufen");
    }

    public void OnAnimationEnd()
    {
        TargetHit?.Invoke();
        Destroy(gameObject, 3);
    }




}
