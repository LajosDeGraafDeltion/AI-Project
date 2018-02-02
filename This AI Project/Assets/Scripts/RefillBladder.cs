using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillBladder : MonoBehaviour {

    public NPCNeeds npcNeeds; //refrencess a different class to use within this one
    public NPCMovement npcMove; //refrencess a different class to use within this one
    public bool timeChange;


    public void OnTriggerEnter(Collider other)
    {

        //When the NPC/Player collides with this object, it's bladder stat will be refilled to the max
        if (other.gameObject.tag == "Player")
        {
            npcNeeds.playerBladder = npcNeeds.maxBladder;
            npcMove.SetDestination();
        }
    }
}