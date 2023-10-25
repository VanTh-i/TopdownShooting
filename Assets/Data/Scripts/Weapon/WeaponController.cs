using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : ThaiBehaviour
{
    [Header("Weapon Stats")]
    public WeaponScriptableObject weaponStats;
    private float currCooldown;

    protected virtual void Start()
    {
        currCooldown = weaponStats.ShootDelay;
    }
    protected virtual void Update()
    {
        CanAttack();
    }

    protected virtual void CanAttack()
    {
        currCooldown -= Time.deltaTime;
        if (currCooldown <= 0f)
        {
            Attack();
        }
    }

    protected virtual void Attack()
    {
        currCooldown = weaponStats.ShootDelay;
    }
}
