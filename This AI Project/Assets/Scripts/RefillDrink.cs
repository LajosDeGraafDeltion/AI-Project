using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillDrink : MonoBehaviour
{

    public NPCNeeds npcNeeds; //refrencess a different class to use within this one
    public NPCMovement npcMove; //refrencess a different class to use within this one
    public bool timeChange;


    public void OnTriggerEnter(Collider other)
    {
        //When the NPC/Player collides with this object, it's thirst stat will be refilled to the max
        if (other.gameObject.tag == "Player")
        {
            npcNeeds.playerThirst = npcNeeds.maxThirst;
            npcMove.SetDestination();
        }
    }
}