using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Cecil.Cil;
using UnityEngine;

public class WeaponController : ThaiBehaviour
{
    [Header("Weapon Stats")]
    public WeaponScriptableObject weaponStats;
    public int currDamage;
    public float currHitDelay;
    public float hitDelay;
    [HideInInspector] public float currPierce;
    [HideInInspector] public float currRange;


    protected override void Awake()
    {
        base.Awake();
        currDamage = weaponStats.Damage;
        hitDelay = weaponStats.HitDelay;
        currPierce = weaponStats.Pierce;
        currRange = weaponStats.Range;
    }
    protected virtual void Start()
    {
        currHitDelay = 0f;
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
            currHitDelay = 0f;
            if (GameManager.Instance.currentState == GameManager.GameState.Paused)
            {
                return;
            }
            Attack();
        }
    }

    protected virtual void Attack()
    {
        currHitDelay = hitDelay;
    }
}
