using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvinciblePickup : Pickup
{
    // Start is called before the first frame update

    public override void DoOnPickup(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.gameObject.GetComponent<Health>() != null)
        {
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            playerHealth.teamId = 1;
            //if (playerHealth.isInvincible == true)
            //{
            //    base.DoOnPickup(collision);
            //}
            //else if (playerHealth.isInvincible == false)
            //{
            //    playerHealth.isInvincible = true;
            //    base.DoOnPickup(collision);
            //}
        }
    }


}
