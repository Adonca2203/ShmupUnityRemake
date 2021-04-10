using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    [SerializeField] GameObject projectilePreFab;
    private GameObject _instantiated;
    public GameObject instantiated { get { return _instantiated; } private set { _instantiated = value; } }
    [SerializeField] private Vector3 offset;
    public Events.AmmoChange onPlayerShoot;

    // Update is called once per frame
    void Update()
    {

        if (PlayerStats.Instance.currentAmmo > 0 && Input.GetButtonDown("Jump"))
        {

            instantiated = Instantiate(projectilePreFab, transform.position + offset, Quaternion.identity);
            onPlayerShoot?.Invoke();

        }

    }

}
