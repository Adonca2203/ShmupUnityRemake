﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D myRigidbody;
    [SerializeField] private PlayerStats stats;
    private int HORIZONTAL_BORDER = 8;
    private int VERTICAL_BORDER = 4;

    // Start is called before the first frame update
    void Start()
    {

        myRigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    { 

        Vector3 change = Vector3.zero;

        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        change.x = Mathf.Round(change.x);
        change.y = Mathf.Round(change.y);

        change.Normalize();

        if (change != Vector3.zero && PlayerStats.Instance.PlayerCurrentState != PlayerStats.PlayerState.dash)
        {

            myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);

            if(myRigidbody.position.x < -HORIZONTAL_BORDER)
            {

                transform.position = new Vector3(-HORIZONTAL_BORDER, transform.position.y, transform.position.z);

            }
            else if(myRigidbody.position.x > HORIZONTAL_BORDER)
            {

                transform.position = new Vector3(HORIZONTAL_BORDER, transform.position.y, transform.position.z);

            }

            if(myRigidbody.position.y < -VERTICAL_BORDER)
            {

                transform.position = new Vector3(transform.position.x, -VERTICAL_BORDER, transform.position.z);

            }

            else if (myRigidbody.position.y > VERTICAL_BORDER)
            {

                transform.position = new Vector3(transform.position.x, VERTICAL_BORDER, transform.position.z);

            }

        }

    }

}
