using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;


public class SafeLevelManager : MonoBehaviour
{

    public GameObject[] Enemies;
    public int currentEnemy;
    //Sterne
    public GameObject Sterne;

    public UnityEvent LevelEnd;
    [SerializeField]

    public UnityEvent Delayed;
    [SerializeField]

    //Countdwon things 
    public TextMeshProUGUI textDisplay;
    public int secondsLeft = 30;
    public bool takingAway = false;
    public bool allEnemiesDefeated = false;
    public bool levelRunning = false;


    void Start()
    {

        foreach (GameObject enemie in Enemies)
        {

            enemie.SetActive(false);
            enemie.transform.Find("Ziel").Find("Glitter").gameObject.SetActive(false);

        }

        Sterne.transform.Find("OneStar").gameObject.SetActive(false);
        Sterne.transform.Find("TwoStars").gameObject.SetActive(false);
        Sterne.transform.Find("ThreeStars").gameObject.SetActive(false);
        Sterne.transform.Find("NoStar").gameObject.SetActive(false);


    }

    public void Update()
    {


        //Timer Stuff

        if (levelRunning == true
             && takingAway == false
             && secondsLeft > 0
             && allEnemiesDefeated == false)
        {
            StartCoroutine(TimerTake()); //Timer starts with Level Start
        }

        if (takingAway == false
            && secondsLeft <= 0
            && allEnemiesDefeated == false
            && levelRunning == true)
        {
            levelRunning = false;
            EndLevel(); //Level Ends when time runs out
            Debug.Log("Time is up!");
        }
    }

    public void StartLevel()
    {

        Enemies[0].SetActive(true);
        currentEnemy = 0;
        levelRunning = true;

    }

    public void ActivateEnemy()
    {
        Debug.Log("ActivateEnemy aufgerufen");
        if (currentEnemy < Enemies.Length - 1)
        {
            Enemies[currentEnemy].SetActive(false);
            currentEnemy += 1;
            Enemies[currentEnemy].SetActive(true);
            Debug.Log("Activated next Enemy");
        }
        else
        {
            Debug.Log("All Enemies Defeated");
            Enemies[currentEnemy].SetActive(false);
            allEnemiesDefeated = true;
            EndLevel();
        }
    }

    public void EndLevel()
    {
        Debug.Log("EndLevel auferufen");
        foreach (GameObject enemie in Enemies)
        {
            enemie.SetActive(false);
        }


        if (allEnemiesDefeated == true)
        {
            if (secondsLeft >= 10)
            {
                // 3 Sterne
                Sterne.transform.Find("ThreeStars").gameObject.SetActive(true);
            }

            if (secondsLeft >= 5 && secondsLeft < 10)
            {
                // 2 Sterne
                Debug.Log("Ergebnis = 1 Stern");
                Sterne.transform.Find("TwoStars").gameObject.SetActive(true);
            }

            if (secondsLeft >= 0 && secondsLeft < 5)
            {
                // 1 Stern
                Debug.Log("Ergebnis = 1 Stern");
                Sterne.transform.Find("OneStar").gameObject.SetActive(true);

            }
        }
        else
        {
            if (currentEnemy == 2)
            {
                // 2 Sterne
                Sterne.transform.Find("TwoStars").gameObject.SetActive(true);
            }

            if (currentEnemy == 1)
            {
                // 1 Stern
                Sterne.transform.Find("OneStar").gameObject.SetActive(true);
            }

            if (currentEnemy == 0)
            {
                // 0 Sterne
                Sterne.transform.Find("NoStar").gameObject.SetActive(true);
            }
        }


        StartCoroutine(CountdownToLevelEnd());
        StartCoroutine(OnDelay());
    }

    IEnumerator CountdownToLevelEnd()
    {
        yield return new WaitForSeconds(4);
        LevelEnd?.Invoke();
    }

    IEnumerator OnDelay()
    {
        yield return new WaitForSeconds(5);
        Delayed?.Invoke();
    }

    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;

        if (secondsLeft < 10)
        {
            textDisplay.text = "00:0" + secondsLeft;
            textDisplay.color = Color.red;
        }
        else
        {
            textDisplay.text = "00:" + secondsLeft;
        }
        takingAway = false;
    }
}