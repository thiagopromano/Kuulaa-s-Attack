using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastlePart : MonoBehaviour
{
    public PlayerTwoDirector castle;

    public Rigidbody2D rb;
    private TargetJoint2D targetJoint2D;
    private bool isMoving = false;
    private BoxCollider2D bc;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        bc = gameObject.GetComponent<BoxCollider2D>();
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
        if (castle.StartMovement())
        {
            isMoving = true;
            rb.freezeRotation = true;
            rb.isKinematic = true;
            bc.enabled = false;
        }
    }

    void OnMouseUp()
    {
        if (isMoving)
        {
            isMoving = false;
            rb.freezeRotation = false;
            bc.enabled = true;
            rb.isKinematic = false;
            castle.EndMovement();
            Destroy(targetJoint2D);
        }
    }
}