using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour
{

    [SerializeField] private GameObject patrolPoints;

    private void Awake()
    {
        Instantiate(patrolPoints);
    }

}