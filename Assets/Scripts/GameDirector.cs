using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameDirector : MonoBehaviour
{

    public PlayerTwoDirector playerTwoDirector;
    
    public int currentPlayer = 1;
    public static GameDirector director;

    void Start()
    {
        GameDirector.director = this;
    }

    public void EndFirstPlayerTurn()
    {
        Debug.Log("End player 1 turn");
        playerTwoDirector.StartTurn();
    }
    public void EndSecondPlayerTurn()
    {
        Debug.Log("End player 2 turn");
    }
}
