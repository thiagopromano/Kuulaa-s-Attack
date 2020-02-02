using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameDirector : MonoBehaviour
{

    public PlayerOneDirector playerOneDirector;
    public PlayerTwoDirector playerTwoDirector;
    public GameObject hook;
    public int currentPlayer = 1;
    public static GameDirector director;
    public GameObject kuulinhaPrefab;
    
    void Start()
    {
        GameDirector.director = this;
    }

    public void EndFirstPlayerTurn()
    {
        Debug.Log("End player 1 turn");
        playerTwoDirector.StartTurn();
        playerOneDirector.EndTurn();
    }
    public void EndSecondPlayerTurn()
    {
        Debug.Log("End player 2 turn");
        playerOneDirector.StartTurn();
    }
}
