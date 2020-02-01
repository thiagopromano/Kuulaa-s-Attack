using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameDirector : MonoBehaviour
{

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
    }
    public void EndSecondPlayerTurn()
    {
        Debug.Log("End player 2 turn");
        var newKuulinhaPosition = hook.transform.position;
        newKuulinhaPosition.z = newKuulinhaPosition.z - 1;
        var newKuulinha = Instantiate(kuulinhaPrefab, newKuulinhaPosition, Quaternion.identity);
        newKuulinha.GetComponent<SpringJoint2D>().connectedBody = hook.GetComponent<Rigidbody2D>();
    }
}
