using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public EnemyScriptableObject enemyStats;
    [HideInInspector] public int currentDamage;
    [HideInInspector] public int currentMaxHp;
    [HideInInspector] public float currentSpeed;
    [HideInInspector] public int currentAttackRange;
    protected virtual void Awake()
    {
        currentDamage = enemyStats.Damage;
        currentMaxHp = enemyStats.MaxHp;
        currentSpeed = enemyStats.Speed;
        currentAttackRange = enemyStats.AttackRange;
    }
}
