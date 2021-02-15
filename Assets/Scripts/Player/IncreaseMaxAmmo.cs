using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseMaxAmmo : ObstacleMovement
{
    public static event Action IncreaseAmmoMax;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            IncreaseAmmoMax?.Invoke();
            Destroy(this.gameObject);

        }

        else
            return;
    }
}
