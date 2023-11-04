using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialController : ThaiBehaviour
{
    [Header("Special Stats")]
    public WeaponScriptableObject specialStats;
    public int currDamage;
    public float currHitDelay;
    public float hitDelay;
    [HideInInspector] public float currPierce;
    [HideInInspector] public float currRange;


    protected override void Awake()
    {
        base.Awake();
        currDamage = specialStats.Damage;
        hitDelay = specialStats.HitDelay;
        currPierce = specialStats.Pierce;
        currRange = specialStats.Range;
    }
    protected virtual void Start()
    {
        currHitDelay = 0f;
    }
    protected virtual void Update()
    {
        CanSpecial();
    }

    protected virtual void CanSpecial()
    {
        currHitDelay -= Time.deltaTime;
        if (currHitDelay <= 0f)
        {
            currHitDelay = 0f;
            Special();
        }
    }

    protected virtual void Special()
    {
        currHitDelay = hitDelay;
    }
}
