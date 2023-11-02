using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : ThaiBehaviour
{
    [Header("Weapon Stats")]
    public WeaponScriptableObject weaponStats;
    public int currDamage;
    [HideInInspector] public float currHitDelay;
    [HideInInspector] public float hitDelay;
    [HideInInspector] public float currSpecialDelay;
    [HideInInspector] public float specialDelay;
    [HideInInspector] public float currPierce;
    [HideInInspector] public float currRange;

    protected override void Awake()
    {
        base.Awake();
        currDamage = weaponStats.Damage;
        //currHitDelay = weaponStats.HitDelay;
        hitDelay = weaponStats.HitDelay;
        specialDelay = weaponStats.SpecialDelay;
        currPierce = weaponStats.Pierce;
        currRange = weaponStats.Range;
    }
    protected virtual void Start()
    {
        currHitDelay = hitDelay;
        currSpecialDelay = specialDelay;
    }
    protected virtual void Update()
    {
        CanAttack();
        CanSpecial();
    }

    protected virtual void CanAttack()
    {
        currHitDelay -= Time.deltaTime;
        if (currHitDelay <= 0f)
        {
            currHitDelay = 0f;
            Attack();
        }
    }

    protected virtual void CanSpecial()
    {
        currSpecialDelay -= Time.deltaTime;
        if (currSpecialDelay <= 0f)
        {
            currSpecialDelay = 0f;
            Special();
        }
    }

    protected virtual void Attack()
    {
        currHitDelay = hitDelay;
    }

    protected virtual void Special()
    {
        currSpecialDelay = specialDelay;
    }
}
