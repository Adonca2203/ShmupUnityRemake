using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public int maxHealth = 3;
    public int maxAmmo = 5;
    public int maxFuel = 4;
    public static event Action ammoHasIncreased;

    private void Start()
    {

        IncreaseMaxAmmo.IncreaseAmmoMax += IncreaseAmmo;

    }

    private void IncreaseAmmo()
    {

        if (maxAmmo < 7)
        {

            maxAmmo++;
            ammoHasIncreased?.Invoke();

        }

    }

}
