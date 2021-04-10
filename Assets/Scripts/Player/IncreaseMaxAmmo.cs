using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseMaxAmmo : ObstacleMovement
{

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            PlayerStats.Instance.IncreaseAmmo(1);
            Destroy(this.gameObject);

        }

        else
            return;
    }
}
