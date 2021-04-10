using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyCollisionHandler : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.CompareTag("Ignore"))
        { return; }

        if (other.CompareTag("Player Projectile"))
        {

            Destroy(this.gameObject);
            Destroy(other.gameObject);

        }

        else if (other.CompareTag("Player"))
        {

            Destroy(this.gameObject);
            PlayerStats.Instance.HealPlayer(-1);

        }

    }

}
