using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneDirector : MonoBehaviour
{
    public Cannon cannon;
    public void EndTurn()
    {
        cannon.enabled = false;
    }
    public void StartTurn()
    {
        cannon.enabled = true;
    }
}
