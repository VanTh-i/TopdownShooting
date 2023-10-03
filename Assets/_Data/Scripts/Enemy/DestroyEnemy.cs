using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : DestroyByDistance
{
    protected override void DestroyObject()
    {
        EnemySpawn.Instance.DestroyEnemy(transform.parent);
    }
}
