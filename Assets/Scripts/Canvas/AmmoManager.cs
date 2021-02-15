using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoManager : MonoBehaviour
{

    public Image AmmoSprites;
    public GameObject[] ammoHolder;
    public GameObject ammoParent;
    public Vector2 parentDefault;
    public static event Action outOfAmmo;
    [SerializeField] private int UsableAmmo;
    [SerializeField] private int MaxAmmo;
    public PlayerStats stats;

    // Start is called before the first frame update
    void Start()
    { 

        UsableAmmo = stats.maxAmmo;
        MaxAmmo = stats.maxAmmo;
        RectTransform ammoRect = ammoParent.GetComponent<RectTransform>();

        parentDefault = ammoRect.localPosition;

        InitAmmo();

        PlayerShoot.PlayerHasShot += DecreaseAmmoCount;
        ProjectileMovement.projectileDestroyed += IncreaseAmmoCount;
        PlayerStats.ammoHasIncreased += SyncAmmo;

    }


    void InitAmmo()
    {

        RectTransform ammoRect = ammoParent.GetComponent<RectTransform>();

        ammoRect.localPosition = parentDefault;

        for (int i = 0; i < ammoHolder.Length; i++)
        {

            ammoHolder[i].gameObject.SetActive(false);

        }

        for(int i = 0; i < UsableAmmo; i++)
        {

            ammoHolder[i].gameObject.SetActive(true);
            ammoRect.localPosition = new Vector2(ammoRect.localPosition.x - 108, ammoRect.localPosition.y);


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

    void SyncAmmo()
    {

        MaxAmmo = FindObjectOfType<PlayerStats>().maxAmmo;
        IncreaseAmmoCount();

    }

}
