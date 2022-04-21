using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagInteraction : MonoBehaviour
{
    [Header("Team Settings")]
    [Tooltip("The role currently assigned 0 for tagger 1 for tagee")]
    public int teamId = 0;

    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            
        }
    }
}
