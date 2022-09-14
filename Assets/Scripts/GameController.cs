using System;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    /* PUBLIC VARIABLES */
    public static GameController Instance;
    private int enemyKillsCounter;


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

    public void EnemyKilled()
    {
        this.enemyKillsCounter++;
    }

    public void EndGame()
    {
        DeadMenu.Instance.ActivateMenu(enemyKillsCounter);
    }
}