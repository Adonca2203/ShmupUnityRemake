using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickoProjectile : MonoBehaviour
{

    [SerializeField] private float speed = 10;
    [SerializeField] private float homingKickIn = .2f;
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody2D myRigidbody;
    private bool homing = false;
    public float playerMissRadius = 1f;
    private bool give_up = false;
    private Vector3 _directionHeading;
    private bool cachedPos = false;

    // Start is called before the first frame update
    void Start()
    {

        myRigidbody = GetComponent<Rigidbody2D>();

        player = FindObjectOfType<PlayerMovement>().gameObject;
        StartCoroutine(TimeToHoming());

    }

    // Update is called once per frame
    void Update()
    {

        if (homing && !give_up)
        {

            FireTowardsPlayer();

        }

        else if (give_up)
        {

            GiveUpChasing();

            myRigidbody.MovePosition(transform.position + _directionHeading * speed * Time.deltaTime);

        }

    }

    private void GiveUpChasing()
    {

        if (!cachedPos)
        {
            Vector3 rayCastDir = -(transform.position - player.transform.position);

            //Debug.Log(rayCastDir);

            RaycastHit2D hit = Physics2D.Raycast(transform.position, rayCastDir);

            if(hit.collider != null)
            {

                //Debug.Log(hit.point);

                Debug.DrawRay(transform.position, rayCastDir * 100, Color.red, 10);

                _directionHeading = hit.point.normalized;

                cachedPos = true;

            }

        }
        else
        {
            return;
        }

    }

    private IEnumerator TimeToHoming()
    {

        yield return new WaitForSeconds(homingKickIn);
        homing = true;

    }

    private void FireTowardsPlayer()
    {

        Vector3 vectorToTarget = player.transform.position - transform.position;

        LookTowardsPlayer();

        if (vectorToTarget.y >= playerMissRadius)
        {

            give_up = true;

        }

        else
        {

            myRigidbody.MovePosition(Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime));

        }

    }

    private void LookTowardsPlayer()
    {

        Vector3 vectorToTarget = (player.transform.position - transform.position).normalized;
        float angle = Mathf.Clamp(Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg, -30, 30);

        if (vectorToTarget.x > 0)
        {
            angle = Mathf.Abs(angle);
        }

        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);

    }

}
