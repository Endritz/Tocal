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

    //private void setTeamID()
    //{
    //    if (gameObject.GetComponent<Health>() != null)
    //        health.teamId = teamId;
    //}

    // Start is called before the first frame update
    private void TagPlayer()
    {
        //give points to player that tags
        GameManager.AddScore(pointValue);

        //give tagee role / removing tager role
        teamId = 1;
        health.currentHealth = 0;
        health.AddLives(2);
        gameObject.tag = "Tag-ee";
        canBeTaggedTest();
    }
    private void TaggedPlayer()
    {
        //give tag role
        //remove tagee role

        teamId = 0;
        gameObject.tag = "Tag-er";
        health.currentHealth = 0;
        health.AddLives(2);
        canBeTaggedTest();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tag-ee" && canBeTagged == false)
        {
            TagPlayer();
        }
        if (collision.gameObject.tag == "Tag-er" && canBeTagged == true)
        {
            TaggedPlayer();
        }    
    }
    private void canBeTaggedTest()
    {
        if(teamId == 0)
        {
            canBeTagged = false;
        }
        else if (teamId == 1)
        {
            canBeTagged = true;
        }
    }
}
