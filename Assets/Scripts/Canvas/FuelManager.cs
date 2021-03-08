using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelManager : MonoBehaviour
{

    [SerializeField] private Slider fuelBar;
    [SerializeField] private float currentFuel;
    [SerializeField] private float maxFuel;
    Coroutine refueling = null;

    // Start is called before the first frame update
    void Start()
    {

        maxFuel = PlayerStats.maxFuel;
        currentFuel = maxFuel;
        fuelBar = GetComponent<Slider>();
        fuelBar.value = 1;
        Dash.hasInputDash += DecreaseFuel;

    }

    private void DecreaseFuel()
    {

        if (currentFuel - 1 <= 0)
        {

            PlayerStats.canDash = false;

        }

        if(currentFuel > 0)
        {

            currentFuel--;
            fuelBar.value -= .25f;

            if (refueling == null) {

                refueling = StartCoroutine(RefuelTimer());

            }

        }

    }

    IEnumerator RefuelTimer()
    {

        yield return new WaitForSeconds(5f);
        IncreaseFuel();
        PlayerStats.canDash = true;

    }

    private void IncreaseFuel()
    {

        if(currentFuel < maxFuel)
        {

            currentFuel++;
            fuelBar.value += .25f;

            if (currentFuel < maxFuel)
            {

                refueling = StartCoroutine(RefuelTimer());

            }

            else
            {

                refueling = null;

            }

        }

    }

}
