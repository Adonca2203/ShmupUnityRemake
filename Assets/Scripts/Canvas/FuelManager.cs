using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelManager : MonoBehaviour
{

    [SerializeField] private Slider fuelBar;
    [SerializeField] private float currentFuel;
    [SerializeField] private float maxFuel;
    [SerializeField] private PlayerStats stats;

    // Start is called before the first frame update
    void Start()
    {

        maxFuel = stats.maxFuel;
        currentFuel = maxFuel;
        fuelBar = GetComponent<Slider>();
        fuelBar.value = 1;
        PlayerMovement.hasInputDash += DecreaseFuel;

    }

    private void DecreaseFuel()
    {

        if(currentFuel > 0)
        {

            currentFuel--;
            fuelBar.value -= .25f;
            StartCoroutine(RefuelTimer());
        }

    }

    IEnumerator RefuelTimer()
    {

        yield return new WaitForSeconds(5f);
        IncreaseFuel();

    }

    private void IncreaseFuel()
    {

        if(currentFuel < maxFuel)
        {

            currentFuel++;
            fuelBar.value += .25f;

        }

    }

}
