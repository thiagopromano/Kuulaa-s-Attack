﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameDirector : MonoBehaviour
{
    public TextMesh shotCount;
    public PlayerOneDirector playerOneDirector;
    public PlayerTwoDirector playerTwoDirector;
    public int currentPlayer = 1;
    public static GameDirector director;
    public GameObject kuulinhaPrefab;
    public GameObject attackScreenPrefab;
    public GameObject defendScreenPrefab;
    public GameObject kuulaaWinScreenPrefab;
    public GameObject kuulaaLoseScreenPrefab;
    public Vector3 screensPos;
    public GameObject sheepees;
    private bool gameEnded = false;
    public int shots = 6;

    void Start()
    {
        GameDirector.director = this;
        StartCoroutine(ShowStartPlayerOne());
    }

    public void EndFirstPlayerTurn()
    {
        if (shots <= 0)
        {
            EndGame(false);
        }
        if (!gameEnded)
            StartCoroutine(ShowStartPlayerTwo());
    }

    public void EndSecondPlayerTurn()
    {
        Debug.Log("End player 2 turn");

        if (!gameEnded)
        {
            StartCoroutine(ShowStartPlayerOne());
        }
    }

    private void Update()
    {
        if (gameEnded && Input.GetKeyDown(KeyCode.Return))
            Application.LoadLevel(Application.loadedLevel);
    }

    public bool oneLessSheep()
    {
        if (sheepees.transform.childCount <= 1)
        {
            EndGame(true);
        }

        return false;
    }

    IEnumerator ShowStartPlayerOne()
    {
        var screen = Instantiate(attackScreenPrefab, attackScreenPrefab.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        Destroy(screen);
        playerOneDirector.StartTurn();
    }

    IEnumerator ShowStartPlayerTwo()
    {
        var screen = Instantiate(defendScreenPrefab, defendScreenPrefab.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        Destroy(screen);
        playerTwoDirector.StartTurn();
        playerOneDirector.EndTurn();
    }

    void EndGame(bool kuulaWin)
    {
        gameEnded = true;
        if (kuulaWin)
             Instantiate(kuulaaWinScreenPrefab, kuulaaWinScreenPrefab.transform.position, Quaternion.identity);
        else
        {
            Instantiate(kuulaaLoseScreenPrefab, kuulaaLoseScreenPrefab.transform.position, Quaternion.identity);
        }
    }

    public void reduceShots()
    {
        shots--;
        shotCount.text = shots.ToString();
    }
}