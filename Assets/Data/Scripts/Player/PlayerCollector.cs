using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CircleCollider2D))]
public class PlayerCollector : ThaiBehaviour
{
    private CircleCollider2D circle;
    public float pullForce;

    protected override void LoadComponents()
    {
        circle = GetComponent<CircleCollider2D>();
        LoadCollider();
    }

    private void LoadCollider()
    {
        circle.isTrigger = true;
        circle.radius = 1.2f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out ICollectible collectible))
        {
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            Vector2 forceDirect = (transform.position - other.transform.position).normalized;
            rb.AddForce(forceDirect * pullForce);

            collectible.Collect();
        }
    }
}
