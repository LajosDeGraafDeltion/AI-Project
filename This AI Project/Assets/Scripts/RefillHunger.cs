using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillHunger : MonoBehaviour {

    public NPCNeeds npcNeeds; //refrencess a different class to use within this one
    public NPCMovement npcMove; //refrencess a different class to use within this one

    void Start () {
		
	}
	

	void Update ()
    {
        //Simple hardcoded function to speed up time with E button
        if (Input.GetKey(KeyCode.E))
        {
            Time.timeScale = 5;
        }

        //Function to reset time to real time
        if (Input.GetKey(KeyCode.F))
        {
            Time.timeScale = 1;
        }
	}

    public void OnTriggerEnter(Collider other)
    {
        //When the NPC/Player collides with this object, it's hunger stat will be refilled to the max
        if (other.gameObject.tag == "Player")
        {
            npcNeeds.playerHunger = npcNeeds.maxHunger;
            npcMove.SetDestination();
            //the NPC/Player returns to it's neutral destination
        }
    }
}
