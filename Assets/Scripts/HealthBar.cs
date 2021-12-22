using System;
using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    /* PUBLIC VARIABLES */
    public int health = 3;
    public bool isDead;

    /* PRIVATE VARIABLES */
    private List<GameObject> _healthBar;

    /*  - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
     *  UNITY FUNCTIONS
     */

    private void Awake()
    {
        _healthBar = new List<GameObject>();

        var healthBarCanvas = transform.GetChild(0);
        for (var i = 0; i < 3; i++)
        {
            _healthBar.Add(healthBarCanvas.GetChild(i).gameObject);
        }
    }

    /*  - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
     *  PUBLIC FUNCTIONS
     */

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health == 0)
        {
            isDead = true;
            return;
        }

        for (var i = 2; i >= health; i--)
        {
            _healthBar[i].SetActive(false);
            Debug.Log($"Health: {health} / i: {i}");
        }
    }
}