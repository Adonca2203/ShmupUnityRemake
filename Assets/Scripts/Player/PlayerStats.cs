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

    public int maxHealth = 3;
    public int maxAmmo = 5;
    public int maxFuel = 4;
    public static event Action ammoHasIncreased;
    public PlayerState currentState;

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
