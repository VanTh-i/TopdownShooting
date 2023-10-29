using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : ThaiBehaviour
{
    [Header("Weapon Stats")]
    public WeaponScriptableObject weaponStats;
    [HideInInspector] public int currDamage;
    [HideInInspector] public float currHitDelay;
    [HideInInspector] public float currPierce;
    [HideInInspector] public float currRange;

    protected override void Awake()
    {
        base.Awake();
        currDamage = weaponStats.Damage;
        currHitDelay = weaponStats.HitDelay;
        currPierce = weaponStats.Pierce;
        currRange = weaponStats.Range;
    }
    protected virtual void Update()
    {
        CanAttack();
    }

    protected virtual void CanAttack()
    {
        currHitDelay -= Time.deltaTime;
        if (currHitDelay <= 0f)
        {
            Attack();
        }
    }

    protected virtual void Attack()
    {
        currHitDelay = weaponStats.HitDelay;
    }
}
