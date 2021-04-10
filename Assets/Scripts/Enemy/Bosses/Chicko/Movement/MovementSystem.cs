using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace ChickoMovement
{
    public class MovementSystem : MonoBehaviour
    {

        [SerializeField] private Transform myPatrolPoints;
        [SerializeField] private List<Transform> allPatrolPoints = new List<Transform>();
        [SerializeField] private Rigidbody2D myRigidBody;
        public float desperation = 0f;
        public int amntOfTravels = 0;
        [SerializeField] private int speed = 5;
        public Vector3 currentlyHeading;
        public bool endOfPath;
        bool canChooseNewLocation = true;
        bool stop = false;
        Vector3 lastHeading;

        // Start is called before the first frame update
        void Start()
        {

            myRigidBody = GetComponent<Rigidbody2D>();

            PopulatePatrols();

        }
        private void PopulatePatrols()
        {

            foreach (Transform child in myPatrolPoints)
            {

                allPatrolPoints.Add(child);

            }

            if (canChooseNewLocation)
            {
                currentlyHeading = ChoosePointToHeadTo().position;
            }

        }

        private void Update()
        {

            lastHeading = currentlyHeading;

            if (amntOfTravels >= Random.Range(5f, 10f))
            {
                amntOfTravels = 0;
                stop = true;
                StartCoroutine(VulnerableTime());


            }

            if (StayOnPath())
            {

                transform.position = Vector3.MoveTowards(transform.position, currentlyHeading, speed * Time.deltaTime);

            }

            else
            {

                if (!stop)
                {
                    currentlyHeading = ChoosePointToHeadTo().position;
                }

            }

        }

        IEnumerator VulnerableTime()
        {

            yield return new WaitForSeconds(1f);
            stop = false;
            endOfPath = true;


        }

        private Transform ChoosePointToHeadTo()
        {

            Transform temp;

            temp = allPatrolPoints[Random.Range(0, allPatrolPoints.Count)];

            return temp.position == lastHeading ? ChoosePointToHeadTo() : temp;

        }

        private bool StayOnPath()
        {

            return endOfPath == true ? endOfPath = false : true;

        }
        private void OnTriggerEnter2D(Collider2D other)
        {

            if (other.CompareTag("EnemyPatrolPoint"))
            {

                endOfPath = true;
                amntOfTravels += 1;

            }

        }

    }
}