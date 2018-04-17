using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElderNeeds : NPCNeeds
{
    public GameObject elderStat;
    public float maxMed;
    public float playerMed;
    public bool uiElder = false;
    public Image med;


    void Start()
    {
        elderStat.SetActive(false);
        StartCoroutine(Medicine());
        StartCoroutine(Hunger());
        StartCoroutine(Thirst());
        StartCoroutine(Joy());
        StartCoroutine(Bladder());

        //Set All Stats
        playerHunger = maxHunger;
        playerThirst = maxThirst;
        playerJoy = maxJoy;
        playerBladder = maxBladder;
        playerMed = maxMed;
    }


    void Update()
    {
        //Set current stats to UI
        playerH.fillAmount = playerHunger / maxHunger;
        playerT.fillAmount = playerThirst / maxThirst;
        playerJ.fillAmount = playerJoy / maxJoy;
        playerB.fillAmount = playerBladder / maxBladder;
        playerB.fillAmount = playerMed / maxMed;

        if (Input.GetButtonDown("Cancel") && uiElder == true)
        {
            uiElder = false;
            elderStat.SetActive(false);
        }
    }

    public IEnumerator Medicine()
    {
        yield return new WaitForSeconds(Random.Range(0.4f, 1.5f));
        playerBladder -= Random.Range(0.1f, 2f);
        StartCoroutine(Bladder());
    }

    public IEnumerator Hunger()
    {
        //Start a timer with a random number to decrease this stat.
        yield return new WaitForSeconds(Random.Range(0.5f, 1f));
        playerHunger -= Random.Range(0.1f, 0.5f); //decrease stat with a random number between 0.1f and 0.5f
        StartCoroutine(Hunger()); //restart coroutine
    }

    public IEnumerator Thirst()
    {
        yield return new WaitForSeconds(Random.Range(0.4f, 0.7f));
        playerThirst -= Random.Range(0.1f, 0.5f);
        StartCoroutine(Thirst());
    }
    public IEnumerator Joy()
    {
        yield return new WaitForSeconds(Random.Range(0.2f, 0.5f));
        playerJoy -= Random.Range(0.1f, 0.5f);
        StartCoroutine(Joy());
    }

    public IEnumerator Bladder()
    {
        yield return new WaitForSeconds(Random.Range(0.4f, 1.5f));
        playerBladder -= Random.Range(0.1f, 1f);
        StartCoroutine(Bladder());
    }

    public void OnMouseDown()
    {
        //If the mouse cursor enters the NPC the UI is turned on
        uiElder = true;
        elderStat.SetActive(true);
    }
}