using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordProjectile : EnemyImpact
{
    protected Transform player;
    private Sword sword;

    private void OnEnable()
    {
        if (sword == null)
        {
            sword = FindObjectOfType<Sword>();
        }
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        player = FindPlayer.GetPlayer();
        if (player == null)
        {
            Debug.LogError("Can not find player");
        }
    }
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (other.gameObject.CompareTag("Enemy"))
        {
            SpawnExplosion();
            if (other.gameObject.TryGetComponent(out EnemyStats enemyStats))
            {
                enemyStats.TakeDamage(sword.GetCurrentDamage(), player.transform.position);
            }
        }
    }
}
