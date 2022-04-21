using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagLogic : MonoBehaviour
{
    [Header("Team Settings")]
    [Tooltip("The role currently assigned 0 for tagger 1 for tagee")]
    public int teamId = 0;
    [Tooltip("Just a check case to see whether or not a player can be tagged based on teamID")]
    public bool canBeTagged;
    [Header("Points")]
    [Tooltip("Assign the amount of points the player gains when tagging another player.")]
    public int pointValue = 0;

    // Start is called before the first frame update
    private void TagPlayer()
    {
        //give points to player that tags
        GameManager.AddScore(pointValue);
        //remove tag role
        //give tagee role
        teamId = 1;
    }
    private void TaggedPlayer()
    {
        //give tag role
        //remove tagee role
        teamId = 0;
    }
    private void TageeIncome()
    {
        //give tag-ee passive income?
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && teamId == 0)
        {
            TagPlayer();
        }
    }
    private void canBeTaggedTest()
    {
        if(teamId == 0)
        {
            canBeTagged = true;
        }
        else if (teamId == 1)
        {
            canBeTagged = false;
        }
    }
}
