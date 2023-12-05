using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyBibleDamage : EnemyImpact
{
    private HolyBible holyBible;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        holyBible = FindObjectOfType<HolyBible>();

    }
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (other.gameObject.TryGetComponent(out EnemyStats enemyStats))
            {
                enemyStats.TakeDamage(holyBible.CurrDamage);
            }
            SpawnExplosion();
        }
    }
}
