using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPackPickup : Pickup
{
    // Start is called before the first frame update
    [Header("JetPack Results")]
    [Tooltip("Increases the effectiveness of the Player's jumping capabilities")]

    public int JumpIncrease = 0;
    public override void DoOnPickup(Collider2D collision)
    {
        if(collision.tag == "Player" && collision.gameObject.GetComponent<Health>() != null)
        {
            PlayerController PController = collision.gameObject.GetComponent<PlayerController>();
            PController.allowedJumps += JumpIncrease;

        }
        base.DoOnPickup(collision);
    }
}
