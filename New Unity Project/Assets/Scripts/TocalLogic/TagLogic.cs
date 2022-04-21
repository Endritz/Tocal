using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagLogic : MonoBehaviour
{
    public Health health;
    [Header("Team Settings")]
    [Tooltip("The role currently assigned 0 for tagger 1 for tagee")]
    public int teamId = 0;
    [Tooltip("Just a check case to see whether or not a player can be tagged based on teamID")]
    public bool canBeTagged;
    [Header("Points")]
    [Tooltip("Assign the amount of points the player gains when tagging another player.")]
    public int pointValue = 0;

    private void TagPlayer()
        //When a player tags another...
    {
        //give points to player that tags
        GameManager.AddScore(pointValue);

        //id is set to 1 which is the Tag-ee - makes canBeTaggedTest easier
        teamId = 1;

        //kills player (in order to respawn them)
        health.currentHealth = 0; 

        //adds lives in order to avoid game ending prematurely
        health.AddLives(2);

        //sets tag = tagee role
        gameObject.tag = "Tag-ee";

        //Changes can be tagged variable based on teamid
        canBeTaggedTest();
    }
    private void TaggedPlayer()
        //When a player gets tagged...
    {
        //team id change to opposite
        teamId = 0;

        //tag changed to tag-er now 
        gameObject.tag = "Tag-er";

        //kills player to be respawned
        health.currentHealth = 0;

        //adds lives so game doesnt end prematurely
        health.AddLives(2);

        //changes canBeTagged bool based on new critera
        canBeTaggedTest();
    }
    private void OnTriggerEnter2D(Collider2D collision)
        //What happens when a player collides with another
    {
        //if the collision happens when someone hits a tag-ee and they themselves cannot be tagged (meaning a tag-er)
        if (collision.gameObject.tag == "Tag-ee" && canBeTagged == false)
        {
            //then the tagplayer function is called
            TagPlayer();
        }
        //if the collision happens when someone hits a tager and they themselves can be tagged (meaning a tag-ee)
        if (collision.gameObject.tag == "Tag-er" && canBeTagged == true)
        {
            //then the taggedplayer function is called
            TaggedPlayer();
        }    
    }
    private void canBeTaggedTest()
        //Swaps the canBeTagged var from true to false and vice versa
    {
        //if the team id is 0
        if(teamId == 0)
        {
            //change the canbetagged var to false
            canBeTagged = false;
        }
        //if the team id isnt 0 (it has to be 1)
        else if (teamId == 1)
        {
            //change the canbetagged var to true
            canBeTagged = true;
        }
    }

}
