using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCNeeds : MonoBehaviour {

    public GameObject statUI;
    public bool uiOn = false;

    // Maximum Stats
    public float maxHunger;
    public float maxThirst;
    public float maxJoy;
    public float maxBladder;

    //Current Stats
    public float playerHunger;
    public float playerThirst;
    public float playerJoy;
    public float playerBladder;

    //Refrence to UI elements
    public Image playerH;
    public Image playerT;
    public Image playerJ;
    public Image playerB;

	void Start ()
    {
        //Set the UI overlay off
        statUI.SetActive(false);
        //Trigger reduction of stats
        StartCoroutine(Hunger());
        StartCoroutine(Thirst());
        StartCoroutine(Joy());
        StartCoroutine(Bladder());

        //Set All Stats
        playerHunger = maxHunger;
        playerThirst = maxThirst;
        playerJoy = maxJoy;
        playerBladder = maxBladder;
    }
	

	void Update ()
    {
        //Set current stats to UI
        playerH.fillAmount = playerHunger / maxHunger;
        playerT.fillAmount = playerThirst / maxThirst;
        playerJ.fillAmount = playerJoy / maxJoy;
        playerB.fillAmount = playerBladder / maxBladder;

        if (Input.GetButtonDown("Cancel") && uiOn == true)
        {
            uiOn = false;
            statUI.SetActive(false);
        }
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
        uiOn = true;
        statUI.SetActive(true);
    }
}
