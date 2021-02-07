using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D myRigidbody;
    public static event Action projectileDestroyed;

    // Start is called before the first frame update
    void Start()
    {

        myRigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        myRigidbody.MovePosition(transform.position + Vector3.up * speed * Time.deltaTime);

    }

    private void OnDestroy()
    {

        projectileDestroyed?.Invoke();

    }

}
