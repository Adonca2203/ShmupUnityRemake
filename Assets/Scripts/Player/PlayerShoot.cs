using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    [SerializeField] GameObject projectilePreFab;
    [SerializeField] private Vector3 offset;
    private int usableProjectileCnt = 5;
    private int maxAmmoCount = 5;
    public static event Action PlayerHasShot;

    // Start is called before the first frame update
    void Start()
    {

        ProjectileMovement.projectileDestroyed += ReloadABullet;
        usableProjectileCnt = PlayerStats.maxAmmo;
        maxAmmoCount = PlayerStats.maxAmmo;

    }

    // Update is called once per frame
    void Update()
    {

        if (usableProjectileCnt > 0)
        {

            if (Input.GetButtonDown("Jump"))
            {

                Instantiate(projectilePreFab, transform.position + offset, Quaternion.identity);
                PlayerHasShot?.Invoke();
                usableProjectileCnt--;

            }

        }

    }

    private void ReloadABullet()
    {

        if (usableProjectileCnt < maxAmmoCount)
        {

            usableProjectileCnt++;

        }

        else
            return;

    }

}
