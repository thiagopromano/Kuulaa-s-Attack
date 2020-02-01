using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    public float health = 2f;
    private void OnCollisionEnter2D(Collision2D colInfo)
    {
        if (colInfo.relativeVelocity.magnitude > health)
        {
            Die();
            return;
        }

        for (int i = 0; i < colInfo.contactCount; i++)
        {
            var contact = colInfo.GetContact(i);
            if (contact.normal.y < -0.4)
            {
                Die();
                return;
            }
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
