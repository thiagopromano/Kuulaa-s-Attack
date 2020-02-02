using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class PlayerTwoDirector : MonoBehaviour
{
    
    public int playerTwoMovements = 0;
    public int maxPlayerTwoMovements = 4;
    public int CastlePartMassReductionMultiplier = 200;
    public float maxImpact = 10f;
    public Vector3 newWoodPosition = new Vector3(0,0, 0);
    public GameObject ExplosionPrefab;
    public GameObject[] WoodParts;
    private GameObject newWood;
    public GameObject optionsPopUpPrefab;
    private GameObject optionsPopUpInstance;
    public bool indestructible = false;

    void Awake()
    {
        for(int i =0;i<gameObject.transform.childCount;i++)
        {
            GameObject g = gameObject.transform.GetChild(i).gameObject;
            if(g.GetComponent<CastlePart>()==null)
            {
                CastlePart castlePart = g.AddComponent<CastlePart>();
                castlePart.castle = this;
            }
        }
    }

    public void StartTurn()
    {
        indestructible = true;
        playerTwoMovements = 0;
        this.enabled = true;
        newWoodForChoose();
    }

    private void newWoodForChoose()
    {
        newWood = Instantiate(WoodParts[Random.Range(0, WoodParts.Length)], newWoodPosition, Quaternion.identity);
        CastlePart castlePart = newWood.AddComponent<CastlePart>();
        castlePart.castle = this;
        castlePart.setNew();

        var pos = newWoodPosition;
        pos.z += 0.1f;
        optionsPopUpInstance = Instantiate(optionsPopUpPrefab, pos, Quaternion.identity);
    }

    public bool StartMovement(bool isNew)
    {
        if (!this.enabled)
            return false;
        if (isNew)
        {
            playerTwoMovements += 100;
            newWood = null;
            Destroy(optionsPopUpInstance);
            return true;
        }
        if (playerTwoMovements >= maxPlayerTwoMovements)
            return false;
        if (newWood != null)
        {
            Destroy(optionsPopUpInstance);
            Destroy(newWood);
            newWood = null;
        }
        playerTwoMovements++;
        return true;
    }

    public void EndMovement()
    {
        if (playerTwoMovements >= maxPlayerTwoMovements)
        {
            indestructible = false;
            GameDirector.director.EndSecondPlayerTurn();
        }

        
    }
}
