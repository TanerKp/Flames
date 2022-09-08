using System;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    /* PUBLIC VARIABLES */
    public static GameController Instance;
    public int EnemyKillsCounter { get; private set; }


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
        this.EnemyKillsCounter++;
    }

    public void EndGame()
    {
        DeadMenu.Instance.ActivateMenu(EnemyKillsCounter);
    }
}