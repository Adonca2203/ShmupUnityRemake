using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{

    public float speed;
    [SerializeField] private Rigidbody2D myRigidbody;

    // Start is called before the first frame update
    void Start()
    {

        myRigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        myRigidbody.MovePosition(transform.position + Vector3.down * speed * Time.deltaTime);

    }
}
