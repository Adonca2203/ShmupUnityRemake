using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Color defaultColor;
    [SerializeField] private Color trans;
    public float shieldTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
        sprite = GetComponent<SpriteRenderer>();
        defaultColor = sprite.color;
        trans = defaultColor;
        trans.a = 0;
        defaultColor.a = 1;
        PlayerStats.Instance.onOverheal.AddListener(EnableShield);
    }

    void EnableShield()
    {

        if (!this.gameObject.activeSelf)
        {

            this.gameObject.SetActive(true);
            StartCoroutine(shieldCountDown());
        }

    }

    IEnumerator shieldCountDown()
    {

        yield return new WaitForSeconds(shieldTime/2);

        StartCoroutine(shieldFlash());

    }

    IEnumerator shieldFlash()
    {

        int temp = 0;
        float flash_invertal = .5f;

        while(temp < 5)
        {

            sprite.color = trans;
            yield return new WaitForSeconds(flash_invertal);
            sprite.color = defaultColor;
            yield return new WaitForSeconds(flash_invertal);
            flash_invertal /= 2;
            temp++;

        }

        this.gameObject.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (this.gameObject.activeSelf && other.gameObject.CompareTag("Enemy"))
        {

            Destroy(other.gameObject);
            this.gameObject.SetActive(false);

        }

    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

}
