using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject bulletPrefab;

    public int Force = 20;
    public float angleAdjustmentFactor = 60f;

    private void Update()
    {
        gameObject.transform.Rotate(Vector3.forward, Input.GetAxis("Mouse ScrollWheel") * angleAdjustmentFactor);
        var angle = gameObject.transform.rotation.eulerAngles.z;
        if (angle > 300)
        {
            gameObject.transform.rotation = Quaternion.Euler(0,0,0);
        }
        else if (angle > 45)
        {
            gameObject.transform.rotation = Quaternion.Euler(0,0,45);
        }
        if (Input.GetKeyDown("space"))
        {
            fire();
        }
    }

    private void fire()
    {
        var pos = transform.position;
        pos.z = -1;
        pos.y -= 0.42f;
        GameObject kuulinha = Instantiate(bulletPrefab, pos, Quaternion.identity);
        var angle = Math.PI * gameObject.transform.rotation.normalized.eulerAngles.z / 180;

        kuulinha.GetComponent<Rigidbody2D>().velocity = new Vector2((float) Math.Cos(angle), (float) Math.Sin(angle))*Force;
    }
}