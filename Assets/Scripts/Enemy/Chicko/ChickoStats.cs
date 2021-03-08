using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickoStats : BossEnemy
{

    private void Start()
    {

        StartCoroutine(Shoot());

    }

    private void Update()
    {
        
    }

    private IEnumerator Shoot()
    {

        yield return new WaitForSeconds(attackRate);

        BasicShot();
        StartCoroutine(Shoot());

    }

}
