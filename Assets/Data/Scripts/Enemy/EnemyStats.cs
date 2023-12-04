using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : ThaiBehaviour
{
    public EnemyScriptableObject enemyStats;
    [HideInInspector] public int currentDamage;
    [HideInInspector] public int currentMaxHp;
    [HideInInspector] public float currentSpeed;
    [HideInInspector] public int currentAttackRange;

    protected override void Awake()
    {
        base.Awake();
        currentDamage = enemyStats.Damage;
        currentMaxHp = enemyStats.MaxHp;
        currentSpeed = enemyStats.Speed;
        currentAttackRange = enemyStats.AttackRange;
    }
    protected virtual void OnEnable()
    {
        currentMaxHp = enemyStats.MaxHp;
    }

    public virtual void TakeDamage(int dmg)
    {
        currentMaxHp -= dmg;
        if (currentMaxHp <= 0)
        {
            currentMaxHp = 0;
        }

        if (!CheckEnemyDead())
        {
            return;
        }
        else
        {
            Kill();
        }

    }
    protected virtual bool CheckEnemyDead()
    {
        if (currentMaxHp <= 0)
        {
            return true;
        }
        else return false;
    }

    protected virtual void Kill()
    {
        // for override
    }
}
