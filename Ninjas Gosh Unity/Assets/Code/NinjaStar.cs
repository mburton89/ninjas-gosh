using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStar : MonoBehaviour
{
    Rigidbody2D rigidBody2D;
    [HideInInspector] public bool hasBeenDeflected;

    private void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    public void Throw(Vector2 direction, float force)
    {
        rigidBody2D.AddForce(direction * force);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("OnTriggerEnter2D");
        if (collision.GetComponent<Player>() && !hasBeenDeflected)
        {
            collision.GetComponent<Player>().Kill();
        }
        else if (collision.GetComponent<Enemy>() && hasBeenDeflected)
        {
            collision.GetComponent<Enemy>().Kill();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("OnCollisionEnter2D");
        if (collision.gameObject.GetComponent<Player>() && !hasBeenDeflected)
        {
            collision.gameObject.GetComponent<Player>().Kill();
        }
        else if (collision.gameObject.GetComponent<Enemy>() && hasBeenDeflected)
        {
            collision.gameObject.GetComponent<Enemy>().Kill();
        }
    }
}
