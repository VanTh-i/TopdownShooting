using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGotKill : DamageReceiver
{
    protected override void Kill()
    {
        EnemySpawn.Instance.DeSpawn(transform.parent);
        SpawnExplosion();
    }

    protected virtual void SpawnExplosion()
    {
        Transform explosion = FxSpawn.Instance.Spawn(transform.position, transform.rotation, 0);
        explosion.gameObject.SetActive(true);
    }
}
