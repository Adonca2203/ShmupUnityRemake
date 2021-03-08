using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    [HideInInspector] public float currentHealth;
    [SerializeField] public float health = 10;
    [SerializeField] public float stressLevel = 1;
    [SerializeField] public float attackRate = 1;
    [SerializeField] public float accuracyPercent = 60;
    [HideInInspector] public int fixedScalingFactor = 20;
    [SerializeField] public GameObject player;
    public GameObject projectile;
    public Vector3 offset;

    private void Start()
    {

        currentHealth = health;
        player = FindObjectOfType<PlayerMovement>().gameObject;

    }

    public void ReduceHealth()
    {

        currentHealth--;

        if ((currentHealth <= health - (health * .3)) && (currentHealth > health - (health * .7)))
        {

            attackRate = (fixedScalingFactor + (health - currentHealth / health * 100)) / 100;

        }

        if (currentHealth <= 0)
        {

            Destroy(this.gameObject);

        }

    }

    public void BasicShot()
    {

        GameObject _projectile = Instantiate(projectile, transform.position + offset, Quaternion.identity);

        /*Vector2 relativePos = player.transform.position - _projectile.transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        _projectile.transform.rotation = transform.rotation = rotation;
        */
    }
    

}
