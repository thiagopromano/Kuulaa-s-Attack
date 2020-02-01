using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject bulletPrefab;

    private float releaseTime = .15f;

    private bool isPressed = false;

    private void Update()
    {
        gameObject.transform.Rotate(Vector3.forward, Input.GetAxis("Mouse ScrollWheel") * 90f);
        if (Input.GetKeyDown("space"))
        {
            fire();
        }
    }

    private void fire()
    {
        GameObject kuulinha = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        var angle = Math.PI * gameObject.transform.rotation.normalized.eulerAngles.z / 180;

        kuulinha.GetComponent<Rigidbody2D>().velocity = new Vector2((float) Math.Cos(angle), (float) Math.Sin(angle))*100;
    }
}