using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class DeadMenu : MonoBehaviour {


    [SerializeField] GameObject EndMenu;
    [SerializeField] Text KillsValue;

    public AudioSource audio;

    public int kills;

    private bool dead = false;

    private void Start()
    {
        kills = 0;
        EndMenu.SetActive(false);
    }

    private void Update()
    {
        if (!dead)
        {
            ActivateMenu();
        }
    }

    void ActivateMenu()
    {
        if (GameObject.Find("Player").GetComponent<HealthBar>().isDead)
        {
            EndMenu.SetActive(true);
            KillsValue.text = kills.ToString();
            audio.Play();
            dead = true;
        }
    }
}
