using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : ThaiBehaviour
{
    [Header("Weapon Stats")]
    public WeaponScriptableObject weaponStats;
    [HideInInspector] public int currDamage;
    [HideInInspector] public float currHitCooldown;
    [HideInInspector] public float currRange;

    protected override void Awake()
    {
        base.Awake();
        currHitCooldown = weaponStats.HitDelay;
        currDamage = weaponStats.Damage;
        currRange = weaponStats.Range;
    }
    protected virtual void Update()
    {
        CanAttack();
    }

    protected virtual void CanAttack()
    {
        currHitCooldown -= Time.deltaTime;
        if (currHitCooldown <= 0f)
        {
            Attack();
        }
    }

    protected virtual void Attack()
    {
        currHitCooldown = weaponStats.HitDelay;
    }
}
