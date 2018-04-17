using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour {

    public Transform destination;
    public Transform getFood;
    public Transform getDrink;
    public Transform getJoy;
    public Transform goToilet;

    public NPCNeeds npcNeeds;

    NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();

        //The "navMeshAgent" is set to it's current component
        if (navMeshAgent == null)
        {
            Debug.LogError("The nav mesh agent is not attached to" + gameObject.name);
            //If the navMeshAgent is not set, an error message will be shown
        }
        else
        {
            SetDestination();
            //If the game finds the NavMashAgent, it will call this function.
        }
    }

    public void Update()
    {
        //All the functions will be called to make the NPC/Player trigger functions, when a stat fall below a certain threshold.
        if (npcNeeds.playerHunger <= 20)
        {
            GetFood();
        }

        if (npcNeeds.playerThirst <= 15)
        {
            GetDrink();
        }

        if (npcNeeds.playerJoy <= 35)
        {
            GetJoy();
        }

        if (npcNeeds.playerBladder <= 10)
        {
            GoToilet();
        }

        if (npcNeeds.playerBladder <= 10)
        {
            GoToilet();
        }

    }

        public void SetDestination()
        {
            //Tell the NPC/Player where to go at when this function is called
            Vector3 targetVector = destination.transform.position;
            navMeshAgent.SetDestination(targetVector);
        }

        void GetFood()
        {
            //If this function is called from the Update Function, the NPC/Player will search this new target
            Vector3 targetVector = getFood.transform.position;
            navMeshAgent.SetDestination(targetVector);
            print("Food");
        }

        void GetDrink()
        {
            Vector3 targetVector = getDrink.transform.position;
            navMeshAgent.SetDestination(targetVector);
            print("Drink");
        }

        void GetJoy()
        {
            Vector3 targetVector = getJoy.transform.position;
            navMeshAgent.SetDestination(targetVector);
            print("Joy");
        }

        void GoToilet()
        {
            Vector3 targetVector = goToilet.transform.position;
            navMeshAgent.SetDestination(targetVector);
            print("Toilet");
        }
}
