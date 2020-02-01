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

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isMoving)
        {
            //rb.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetJoint2D.target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    void OnMouseDown()
    {
        // rb.isKinematic = true;
        
        isMoving = castle.StartMovement();
        if (isMoving)
        {
            targetJoint2D = gameObject.AddComponent<TargetJoint2D>();
            
            targetJoint2D.anchor = gameObject.transform.InverseTransformPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            //targetJoint2D.frequency = 1000;
        }
    }

    void OnMouseUp()
    {
        if (isMoving)
        {
            isMoving = false;
            // rb.isKinematic = false;
            castle.EndMovement();
            Destroy(targetJoint2D);
        }
    }
}