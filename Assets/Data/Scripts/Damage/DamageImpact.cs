using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class DamageImpact : ThaiBehaviour
{
    [SerializeField] DamageSender damageSender;
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        damageSender.Send(other.transform);
    }
}
