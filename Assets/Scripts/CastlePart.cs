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
    private bool isNew = false;

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

        isMoving = castle.StartMovement(isNew);
        isNew = false;
        if (isMoving)
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.simulated = true;
            targetJoint2D = gameObject.AddComponent<TargetJoint2D>();

            targetJoint2D.anchor =
                gameObject.transform.InverseTransformPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));

            rb.mass = rb.mass / castle.CastlePartMassReductionMultiplier;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D colInfo)
    {
        if (colInfo.relativeVelocity.magnitude > castle.maxImpact && !castle.indestructible)
        {
            Die();
        }
    }
    
    private void Die()
    {
        Instantiate(castle.ExplosionPrefab, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnMouseUp()
    {
        if (isMoving)
        {
            isMoving = false;
            // rb.isKinematic = false;
            castle.EndMovement();
            rb.constraints = RigidbodyConstraints2D.None;
            rb.mass = rb.mass * castle.CastlePartMassReductionMultiplier;
            Destroy(targetJoint2D);
        }
    }

    public void setNew()
    {
        isNew = true;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}