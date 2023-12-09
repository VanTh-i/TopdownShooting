using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningExplosion : DestroyByTime
{
    // keo prefab ve lai pool
    protected override void DestroyObject()
    {
        FxSpawn.Instance.DeSpawn(transform.parent);
    }
}
