using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGotKill : DamageReceiver
{
    protected EnemyStats enemyStats;
    private EnemySpawnSystem enemySpawn;


    protected override void Awake()
    {
        base.Awake();
        enemyStats = GetComponentInParent<EnemyStats>();
        currentHp = enemyStats.currentMaxHp;
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        enemySpawn = FindObjectOfType<EnemySpawnSystem>();
    }
    protected override void Kill()
    {
        EnemySpawn.Instance.DeSpawn(transform.parent);
        enemySpawn.OnEnemyKilled();
        SpawnExplosion();
    }

    protected virtual void SpawnExplosion()
    {
        Transform explosion = FxSpawn.Instance.Spawn(transform.position, transform.rotation, 0);
        explosion.gameObject.SetActive(true);
    }
}
