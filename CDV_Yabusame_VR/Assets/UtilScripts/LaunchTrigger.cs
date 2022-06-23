using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


public class LaunchTrigger : MonoBehaviour
{
    /*
    // Delegate -> Kommuniziert, dass der Bogenschuß erfolgt ist
    public UnityEvent OnBowShot;

    [SerializeField, Tooltip("Reference to the InputAction")]
    private InputActionReference triggerRef;

    private GameObject grabPoint = null;
    private bool grab = false;

    void Awake()
    {
        triggerRef.action.started += StartGrabbing;
        triggerRef.action.canceled += Fire;
    }

    void Update()
    {

        if(grab)
        {
            grabPoint.transform.position = this.transform.position;
        }

    }

    private void OnDestroy()
    {
        triggerRef.action.started -= StartGrabbing;
        triggerRef.action.canceled -= Fire;
    }

    private void Fire(InputAction.CallbackContext ctx)
    {
        // Todo (Optimization): Check if the player has 
        // stretched the bowstring apart
        if (grab)
        {
            OnBowShot?.Invoke();
            grab = false;
        }
        
    }

    private void StartGrabbing(InputAction.CallbackContext ctx)
    {
        if(grabPoint != null)
        {
            grab = true;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        grabPoint = collider.gameObject;
    }

    private void OnTriggerExit(Collider collider)
    {
        grabPoint = null;
    }*/

    // Delegate -> Kommuniziert, dass der Bogenschuß erfolgt ist
    public UnityEvent OnBowShot;
    public UnityEvent OnTriggerEnd;

    [SerializeField, Tooltip("Reference to the InputAction")]
    private InputActionReference triggerRef;

    [SerializeField, Tooltip("Required tension to fire in unity meters")]
    private float requiredTension;

    private GameObject grabPoint = null;
    private Vector3 grabPointStart;

    private bool grab = false;

    void Awake()
    {
        triggerRef.action.started += StartGrabbing;
        triggerRef.action.canceled += Fire;
    }

    void Update()
    {

        if (grab)
        {
            grabPoint.transform.position = this.transform.position;
        }

    }

    private void OnDestroy()
    {
        triggerRef.action.started -= StartGrabbing;
        triggerRef.action.canceled -= Fire;
    }

    private void Fire(InputAction.CallbackContext ctx)
    {
        if (grab && BowstringTensioned())
        {
            OnBowShot?.Invoke();
        }
        else
        {
            OnTriggerEnd?.Invoke();
        }

        grab = false;
    }

    private bool BowstringTensioned()
    {
        float tension = Vector3.Distance(grabPointStart, this.transform.position);
        return tension > requiredTension;
    }


    private void StartGrabbing(InputAction.CallbackContext ctx)
    {
        if (grabPoint != null)
        {
            grab = true;
            grabPointStart = grabPoint.transform.position;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        grabPoint = collider.gameObject;
    }

    private void OnTriggerExit(Collider collider)
    {
        grabPoint = null;
    }

}
