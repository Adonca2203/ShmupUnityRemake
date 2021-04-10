using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPowerUp : ObstacleMovement
{

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            PlayerStats.Instance.HealPlayer(1);
            Destroy(this.gameObject);

        }

        else
            return;
    }

}
