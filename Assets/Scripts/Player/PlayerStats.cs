using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{

    normal,
    dash,
    hurt

}

public class PlayerStats : MonoBehaviour
{

    public static int maxHealth = 3;
    public static int maxAmmo = 5;
    public static int maxFuel = 4;
    public static event Action ammoHasIncreased;
    public static PlayerState currentState;
    public static bool canDash = true;

    private void Start()
    {

        IncreaseMaxAmmo.IncreaseAmmoMax += IncreaseAmmo;
        currentState = PlayerState.normal;

    }

    private void IncreaseAmmo()
    {

        if (maxAmmo < 7)
        {

            maxAmmo++;
            ammoHasIncreased?.Invoke();

        }

    }

    public void ChangeState(PlayerState newState)
    {

        if (currentState != newState)
        {

            currentState = newState;

        }

    }

}
