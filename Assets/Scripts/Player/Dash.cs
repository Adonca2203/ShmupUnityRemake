using System;
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
    [SerializeField] private PlayerStats stat;
    private int leftTapCnt = 0;
    private int rightTapCnt = 0;
    private float buttonResetTime = .2f;
    private bool listenForAUp = false;
    private bool listenForDUp = false;
    private float lastLeftRelease;
    private float lastRightRelease;

    // Start is called before the first frame update
    void Start()
    {

        myRigidbody = GetComponent<Rigidbody2D>();
        stat = GetComponent<PlayerStats>();

    }

    // Update is called once per frame
    void Update()
    {

        if(stat.currentState != PlayerState.dash)
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
        stat.ChangeState(PlayerState.dash);
        hasInputDash?.Invoke();
        StartCoroutine(DashCo());

    }

    IEnumerator DashCo()
    {

        yield return new WaitForSeconds(dashTime);
        myRigidbody.velocity = Vector2.zero;
        stat.ChangeState(PlayerState.normal);


    }

}
