using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullHealthPickup : Pickup
{

    public override void DoOnPickup(Collider2D collision)
    {
        //The thing colliding into the pickup must be the player and the player must have health.
        if (collision.tag == "Player" && collision.gameObject.GetComponent<Health>() != null) 
        {
            //getting the components of Health
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            //the player must have less than max health in order to be healed at all otherwise
            //only the base function will happen
            if(playerHealth.currentHealth < playerHealth.maximumHealth)
            {
                //player recieives healing equal to the maxiumum health offered to the player.
                playerHealth.ReceiveHealing(playerHealth.maximumHealth);
                //this will remove the pickup from the scene (function is located in Pickup.cs)
                base.DoOnPickup(collision);
            }

        }
    }
}