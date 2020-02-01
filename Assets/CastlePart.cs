using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastlePart : MonoBehaviour
{
    public PlayerTwoDirector castle;

    public Rigidbody2D rb;

    private bool isMoving = false;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isMoving)
        {
            rb.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    void OnMouseDown()
    {
        rb.isKinematic = true;
        isMoving = castle.StartMovement();
    }

    void OnMouseUp()
    {
        if (isMoving)
        {
            isMoving = false;
            rb.isKinematic = false;
            castle.EndMovement();
        }
    }
}