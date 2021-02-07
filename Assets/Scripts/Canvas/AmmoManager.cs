using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoManager : MonoBehaviour
{

    public Image[] AmmoSprites;
    public static event Action outOfAmmo;
    [SerializeField] private int UsableAmmo;
    [SerializeField] private int MaxAmmo;
    [SerializeField] private PlayerStats stats;

    // Start is called before the first frame update
    void Start()
    {

        UsableAmmo = stats.maxAmmo;
        MaxAmmo = stats.maxAmmo;

        InitAmmo();

        PlayerShoot.PlayerHasShot += DecreaseAmmoCount;
        ProjectileMovement.projectileDestroyed += IncreaseAmmoCount;

    }


    void InitAmmo()
    {

        for(int i = 0; i < MaxAmmo; i++)
        {

            AmmoSprites[i].gameObject.SetActive(false);

        }

        for(int i = 0; i < UsableAmmo; i++)
        {

            AmmoSprites[i].gameObject.SetActive(true);

        }

    }

    void DecreaseAmmoCount()
    {

        UsableAmmo--;

        if(UsableAmmo <= 0)
        {

            outOfAmmo?.Invoke();

        }

        InitAmmo();

    }

    void IncreaseAmmoCount()
    {

        if (UsableAmmo < MaxAmmo)
        {

            UsableAmmo++;
            InitAmmo();

        }

    }
}
