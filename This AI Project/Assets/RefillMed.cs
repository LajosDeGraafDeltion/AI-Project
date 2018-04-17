using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillMed : MonoBehaviour
{

    public ElderNeeds elderNeeds; //refrencess a different class to use within this one
    public ElderMovement elderMove; //refrencess a different class to use within this one
    public bool timeChange;


    public void OnTriggerEnter(Collider other)
    {
        //When the NPC/Player collides with this object, it's joy stat will be refilled to the max
        if (other.gameObject.tag == "Player")
        {
            elderNeeds.playerJoy = elderNeeds.maxMed;
            elderMove.SetDestination();
        }
    }
}