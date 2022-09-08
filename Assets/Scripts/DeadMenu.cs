using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class DeadMenu : MonoBehaviour
{
    /* PUBLIC VARIABLES */
    public static DeadMenu Instance;

    /* SERIALIZED VARIABLES */
    [SerializeField] GameObject endMenu;
    [SerializeField] Text killsValue;


    /*  - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
     *  UNITY FUNCTIONS
     */
    
    private void Awake()
    {
        if (!Instance) Instance = this;
    }

    
    /*  - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
     *  PUBLIC FUNCTIONS
     */
    
    public void ActivateMenu(int kills)
    {
        endMenu.SetActive(true);
        killsValue.text = kills.ToString();
        GetComponent<AudioSource>().Play();
    }
}
