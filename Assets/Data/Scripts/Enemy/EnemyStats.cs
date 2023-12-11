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

    [Header("Damage Feedback")]
    protected Color dmgColor = new Color(1, 0, 0, 1);
    protected Color originalColor;
    protected SpriteRenderer enemySprite;
    protected EnemyMovement movement;
    private float knockbackForce = 5f;
    private float knockbackDuration = 0.2f;

    protected override void Awake()
    {
        base.Awake();
        currentDamage = enemyStats.Damage;
        currentMaxHp = enemyStats.MaxHp;
        currentSpeed = enemyStats.Speed;
        currentAttackRange = enemyStats.AttackRange;

        movement = transform.parent.GetChild(0).GetComponent<EnemyMovement>();
    }
    protected virtual void OnEnable()
    {
        currentMaxHp = enemyStats.MaxHp;
        enemySprite = GetComponentInParent<SpriteRenderer>();
        originalColor = enemySprite.color;
    }

    public virtual void TakeDamage(int dmg, Vector2 sourcePosition)
    {
        currentMaxHp -= dmg;
        StartCoroutine(DamageFlash());

        if (knockbackForce > 0)
        {
            Vector2 dir = (Vector2)transform.parent.position - sourcePosition;
            movement.Knockback(dir.normalized * knockbackForce, knockbackDuration);
        }

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

    protected IEnumerator DamageFlash()
    {
        enemySprite.color = dmgColor;
        yield return new WaitForSeconds(0.2f);
        enemySprite.color = originalColor;
    }

    protected virtual void Kill()
    {
        // for override
    }

    protected void OnDisable()
    {
        enemySprite.color = originalColor;
    }
}
