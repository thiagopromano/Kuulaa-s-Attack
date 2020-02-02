using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject pivot;

    public int Force = 20;
    public float angleAdjustmentFactor = 60f;
    public float AngleMax = 80f;
    public float angleOffset = 10f;

    private void Update()
    {
        pivot.transform.Rotate(Vector3.forward, Input.GetAxis("Mouse ScrollWheel") * angleAdjustmentFactor);
        var angle = pivot.transform.rotation.eulerAngles.z;
        if (angle > 300)
        {
            pivot.transform.rotation = Quaternion.Euler(0,0,0);
        }
        else if (angle > AngleMax)
        {
            pivot.transform.rotation = Quaternion.Euler(0,0,AngleMax);
        }
        if (Input.GetKeyDown("space"))
        {
            fire();
            this.enabled = false;
        }
    }

    private void fire()
    {
        var pos = transform.position;
        pos.z = -4;
        pos.y -= 0.42f;
        GameObject kuulinha = Instantiate(bulletPrefab, pos, Quaternion.identity);
        var angle = Math.PI * (gameObject.transform.rotation.normalized.eulerAngles.z+angleOffset) / 180;

        kuulinha.GetComponent<Rigidbody2D>().velocity = new Vector2((float) Math.Cos(angle), (float) Math.Sin(angle))*Force;
    }
}