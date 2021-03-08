using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyCollisionHandler : MonoBehaviour
{

    public static event Action PlayerWasHit;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player Projectile"))
        {

            Destroy(this.gameObject);
            Destroy(other.gameObject);

        }

        else if (other.CompareTag("Player"))
        {

            Destroy(this.gameObject);
            PlayerWasHit?.Invoke();

        }

    }

}
