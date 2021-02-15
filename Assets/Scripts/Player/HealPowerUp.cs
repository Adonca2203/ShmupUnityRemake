using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPowerUp : ObstacleMovement
{

    public static event Action pickedupHeal;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            pickedupHeal?.Invoke();
            Destroy(this.gameObject);

        }

        else
            return;
    }

}
