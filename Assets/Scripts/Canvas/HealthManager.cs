using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    public Image[] healthSprites;
    public static event Action playerHasDied;

    // Start is called before the first frame update
    void Start()
    {

        InitHealth();
        PlayerStats.Instance.onHealthChange.AddListener(InitHealth);

    }

    void InitHealth()
    {

        for(int i = 0; i < PlayerStats.Instance.maxHealth; i++)
        {

            healthSprites[i].gameObject.SetActive(false);

        }

        for(int i = 0; i < PlayerStats.Instance.currentHealth; i++)
        {

            healthSprites[i].gameObject.SetActive(true);

        }

    }

}
