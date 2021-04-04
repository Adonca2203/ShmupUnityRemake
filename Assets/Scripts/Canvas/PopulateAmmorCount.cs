using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateAmmorCount : MonoBehaviour
{

    [SerializeField] private GameObject AmmoUIPrefab;
    private int _currentAmmo = 0;

    private void Start()
    {
        _currentAmmo = PlayerStats.Instance.maxAmmo;
    }

}
