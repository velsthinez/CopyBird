using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Player"))
            return;

        Flappy player = col.gameObject.GetComponent<Flappy>();

        if (player == null)
            return;
        
        player.Die();

    }
}
