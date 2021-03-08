using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {

        if(this.CompareTag("OutOfBounds"))
        {

            Destroy(other.gameObject);

        }

    }

}
