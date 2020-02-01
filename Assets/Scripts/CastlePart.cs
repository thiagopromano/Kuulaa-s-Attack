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
    public int massReductionMultiplier = 200;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isMoving)
        {
            targetJoint2D.target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rb.rotation += Input.GetAxis("Mouse ScrollWheel") * 90f;
        }
    }

    void OnMouseDown()
    {
        // rb.isKinematic = true;

        isMoving = castle.StartMovement();
        if (isMoving)
        {
            targetJoint2D = gameObject.AddComponent<TargetJoint2D>();

            targetJoint2D.anchor =
                gameObject.transform.InverseTransformPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));

            rb.mass = rb.mass / massReductionMultiplier;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    void OnMouseUp()
    {
        if (isMoving)
        {
            isMoving = false;
            // rb.isKinematic = false;
            castle.EndMovement();
            rb.constraints = RigidbodyConstraints2D.None;
            rb.mass = rb.mass * massReductionMultiplier;
            Destroy(targetJoint2D);
        }
    }
}