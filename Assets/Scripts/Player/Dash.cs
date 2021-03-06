﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dash : MonoBehaviour
{

    public float dashSpeed;
    public float dashTime;
    public static event Action hasInputDash;
    [SerializeField] private Rigidbody2D myRigidbody;
    private float buttonResetTime = .1f;
    private bool listenForAUp = false;
    private bool listenForDUp = false;
    private float lastLeftRelease;
    private float lastRightRelease;

    // Start is called before the first frame update
    void Start()
    {

        myRigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if(PlayerStats.Instance.PlayerCurrentState != PlayerStats.PlayerState.dash && PlayerStats.Instance.canDash)
        {

            if (Input.GetKeyDown(KeyCode.A))
            {

                if (listenForAUp && Time.time - lastLeftRelease <= buttonResetTime)
                    DashIn(Vector2.left);

                else
                    listenForAUp = true;

            }

            if (Input.GetKeyDown(KeyCode.D))
            {

                if (listenForDUp && Time.time - lastRightRelease <= buttonResetTime)
                    DashIn(Vector2.right);

                else
                    listenForDUp = true;

            }

            if (listenForAUp)
            {

                if (Input.GetKeyUp(KeyCode.A))
                {

                    lastLeftRelease = Time.time;
                    StartCoroutine(ResetTaps());

                }

            }

            if (listenForDUp)
            {

                if (Input.GetKeyUp(KeyCode.D))
                {

                    lastRightRelease = Time.time;
                    StartCoroutine(ResetTaps());

                }

            }

        }

    }

    private IEnumerator ResetTaps()
    {
        yield return new WaitForSeconds(buttonResetTime);
        listenForAUp = false;
        listenForAUp = false;
    }

    void DashIn(Vector2 direction)
    {

        myRigidbody.AddForce(direction * dashSpeed, ForceMode2D.Impulse);
        PlayerStats.Instance.ChangeState(PlayerStats.PlayerState.dash);
        hasInputDash?.Invoke();
        StartCoroutine(DashCo());

    }

    IEnumerator DashCo()
    {

        yield return new WaitForSeconds(dashTime);
        myRigidbody.velocity = Vector2.zero;
        PlayerStats.Instance.ChangeState(PlayerStats.PlayerState.normal);


    }

}
