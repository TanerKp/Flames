using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour, IHealthBar
{
    /* SERIALIZED VARIABLES */
    [SerializeField] private List<GameObject> healthBarObjects;

    /*  - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
     *  PUBLIC FUNCTIONS
     */

    public void Initialize()
    {
        healthBarObjects = new List<GameObject>();

        var healthBarCanvas = transform.GetChild(0);
        for (var i = 0; i < 3; i++)
        {
            healthBarObjects.Add(healthBarCanvas.GetChild(i).gameObject);
        }
    }

    public void ShowHealth(int health)
    {
        for (var i = 2; i >= health; i--)
        {
            healthBarObjects[i].SetActive(false);
        }
    }
}