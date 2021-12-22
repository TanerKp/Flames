using System;
using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;

public class HealthBar : MonoBehaviour, IHealthBar
{
    /* PRIVATE VARIABLES */
    public List<GameObject> healthBarObjects;

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
            Debug.Log($"i: {i} / Health: {health}");
            healthBarObjects[i].SetActive(false);
        }
    }
}