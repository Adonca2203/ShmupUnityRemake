using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnableObjects{

    public GameObject objects;
    public float objectChance;
    public string objectName;

}

public class EnemySpawner : MonoBehaviour
{
    public SpawnableObjects[] spawnableObjects;
    private string lastObject;
    public float waitTime = 1f;

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

        Instantiate(ChooseObject(), ChooseSpawnLocation(), Quaternion.identity);

        yield return new WaitForSeconds(waitTime);

        StartCoroutine(SpawnObstacle());

    }

    private Vector3 ChooseSpawnLocation()
    {

        return new Vector3(Random.Range(-8, 9), transform.position.y, 0);

    }

    private GameObject ChooseObject()
    {

        float cumulativeProbability = 0f;
        float currentProbability = Random.Range(0, 100);

        if(lastObject == "Health")
        {

            lastObject = "";
            return spawnableObjects[1].objects;

        }

        for(int i = 0; i < spawnableObjects.Length; i++)
        {

            cumulativeProbability += spawnableObjects[i].objectChance;

            if(currentProbability < cumulativeProbability)
            {

                lastObject = spawnableObjects[i].objectName;
                return spawnableObjects[i].objects;

            }

        }

        return null;

    }

}
