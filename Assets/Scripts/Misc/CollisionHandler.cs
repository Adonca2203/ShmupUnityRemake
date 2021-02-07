using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{

    public static event Action PlayerWasHit;

    private void OnTriggerEnter2D(Collider2D other)
    {


        if ((other.CompareTag("Enemy") && this.CompareTag("Player Projectile")) || (other.CompareTag("Player Projectile") && this.CompareTag("Enemy")))
        {

            Destroy(this.gameObject);
            Destroy(other.gameObject);

        }

        else if(other.CompareTag("Player") && this.CompareTag("Player Projectile"))
        {

            return;

        }

        else if(other.CompareTag("Enemy") && this.CompareTag("Player"))
        {

            Destroy(other.gameObject);

            PlayerWasHit?.Invoke();

        }

        else if(this.CompareTag("Enemy") && other.CompareTag("Player"))
        {

            Destroy(this.gameObject);

            PlayerWasHit?.Invoke();

        }

        else if(this.CompareTag("OutOfBounds"))
        {

            Destroy(other.gameObject);

        }

    }

}
