using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private GameObject obstaclePreFab;
    public float waitTime;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(SpawnObstacle());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnObstacle()
    {

        Instantiate(obstaclePreFab, ChooseSpawnLocation(), Quaternion.identity);

        yield return new WaitForSeconds(waitTime);

        StartCoroutine(SpawnObstacle());

    }

    private Vector3 ChooseSpawnLocation()
    {

        return new Vector3(Random.Range(-8, 9), transform.position.y, 0);

    }

}
