using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    public Image[] healthSprites;
    [SerializeField] private int MaxHP;
    [SerializeField] private int CurrentHP;
    [SerializeField] private PlayerStats stats;
    public static event Action playerHasDied;
    public static event Action raiseShield;

    // Start is called before the first frame update
    void Start()
    {

        InitHealth();
        MaxHP = stats.maxHealth;
        CurrentHP = MaxHP;

        CollisionHandler.PlayerWasHit += ReduceHealth;
        HealPowerUp.pickedupHeal += IncreaseHealth;

    }

    void InitHealth()
    {

        for(int i = 0; i < MaxHP; i++)
        {

            healthSprites[i].gameObject.SetActive(false);

        }

        for(int i = 0; i < CurrentHP; i++)
        {

            healthSprites[i].gameObject.SetActive(true);

        }

    }

    void ReduceHealth()
    {

        CurrentHP--;

        if(CurrentHP <= 0)
        {

            playerHasDied?.Invoke();

        }

        InitHealth();

    }

    void IncreaseHealth()
    {

        if(CurrentHP < MaxHP)
        {

            CurrentHP++;
            InitHealth();

        }

        else
        {

            raiseShield?.Invoke();

        }

    }

}
