using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class IntroManager : MonoBehaviour
{
    public GameObject[] Colliders;
    public int currentCollider;
    public GameObject[] Riders;
    public int currentRider;

    public TextMeshProUGUI textDisplay;

    public UnityEvent Delayed;
    [SerializeField]

    public UnityEvent IntroEnd;
    [SerializeField]


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Intro Manager aufgerufen");
        foreach (GameObject collider in Colliders)
        {

            collider.SetActive(false);
        }

        foreach (GameObject rider in Riders)
        {

            rider.SetActive(false);
        }

        textDisplay.text = "";
        textDisplay.color = Color.black;

        StartCoroutine(OnDelay());

    }
    public void StartIntro()
        {
        Debug.Log("0th rider and collider activated");
            Colliders[0].SetActive(true);
            currentCollider = 0;
            Riders[0].SetActive(true);
            currentRider = 0;
        Debug.Log("0th rider and collider activated");


    }

    IEnumerator OnDelay()
    {
        yield return new WaitForSeconds(1);
        Delayed?.Invoke();
    }


    public void ActivateNextstep()
    {
        Debug.Log("ActivateNexststep aufgerufen");
        if (currentRider < Riders.Length - 1)
        {
            Colliders[currentCollider].SetActive(false);
            currentCollider += 1;
            Riders[currentRider].SetActive(false);
            currentRider += 1;
            Debug.Log("Deactivated");
            Colliders[currentCollider].SetActive(true);
            Riders[currentRider].SetActive(true);
            Debug.Log("Activated next Step");
        }
        else
        {
            Colliders[currentCollider].SetActive(false);
            Debug.Log("Last deactivation");
            IntroEnd?.Invoke();
          //  textDisplay.text = "00:30";
          //  StartCoroutine(CountdownToIntroEnd())
        }
    }

    public void Activation()
    {
        gameObject.SetActive(true);
    }

    public void Deactivation()
    {
        gameObject.SetActive(false);
    } 


    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
