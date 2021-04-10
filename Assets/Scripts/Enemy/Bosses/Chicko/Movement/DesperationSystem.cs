using ChickoMovement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesperationSystem : MonoBehaviour
{

    private MovementSystem MovementSystem;

    private void Start()
    {
        MovementSystem = GetComponent<MovementSystem>();
    }

    private void Update()
    {

        if (MovementSystem.desperation <= 0)
        {

            return;

        }
        else
        {

            StartCoroutine(NewLocationCooler());

        }

    }

    IEnumerator NewLocationCooler()
    {

        yield return new WaitForSeconds(Mathf.Clamp(1 - MovementSystem.desperation / 100, 0, .7f));
        MovementSystem.endOfPath = true;

    }

}
