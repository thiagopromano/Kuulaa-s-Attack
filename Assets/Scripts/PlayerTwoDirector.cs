using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoDirector : MonoBehaviour
{
    
    public int playerTwoMovements = 0;
    public int maxPlayerTwoMovements = 4;
    public int CastlePartMassReductionMultiplier = 200;

    void Awake()
    {
        for(int i =0;i<gameObject.transform.childCount;i++)
        {
            GameObject g = gameObject.transform.GetChild(i).gameObject;
            if(g.GetComponent<CastlePart>()==null)
            {
                CastlePart castlePart = g.AddComponent<CastlePart>();
                castlePart.castle = this;
                castlePart.massReductionMultiplier = CastlePartMassReductionMultiplier;
            }
        }
    }

    public void StartTurn()
    {
        playerTwoMovements = 0;
        this.enabled = true;
    }

    public bool StartMovement()
    {
        if (!this.enabled)
            return false;
        if (playerTwoMovements >= maxPlayerTwoMovements)
            return false;
        playerTwoMovements++;
        return true;
    }

    public void EndMovement()
    {
        if (playerTwoMovements >= maxPlayerTwoMovements)
            GameDirector.director.EndSecondPlayerTurn();
    }
}
