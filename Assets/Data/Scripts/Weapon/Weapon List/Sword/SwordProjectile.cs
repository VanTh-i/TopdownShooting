using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordProjectile : EnemyImpact
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (other.gameObject.CompareTag("Enemy"))
        {
            SpawnExplosion();
            if (other.gameObject.TryGetComponent(out EnemyStats enemyStats))
            {
                enemyStats.TakeDamage(GetCurrentDamage());
            }
        }
    }
}
