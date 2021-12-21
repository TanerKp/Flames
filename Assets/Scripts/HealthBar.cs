using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public int health;
    public bool isDead = false;

    public bool GodMode = false;

    [Space(10)]
    [SerializeField] GameObject HealthBar1;
    [SerializeField] GameObject HealthBar2;
    [SerializeField] GameObject HealthBar3;


    private void Start()
    {
        if (GodMode)
        {
            health = 1000;
        }
        health = 4;
        isDead = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        switch (health)
        {
            case 3:
                HealthBar1.SetActive(true);
                HealthBar2.SetActive(true);
                HealthBar3.SetActive(true);
                break;
            case 2:
                HealthBar3.SetActive(false);
                break;
            case 1:
                HealthBar2.SetActive(false);
                break;
            case 0:
                isDead = true;
                break;
        }
    }
}
