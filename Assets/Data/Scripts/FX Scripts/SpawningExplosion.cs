using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningExplosion : DestroyByTime
{
    //sau khi class enemtgotkill chay thi keo prefab exp ve lai pool
    protected override void DestroyObject()
    {
        FxSpawn.Instance.DeSpawn(transform.parent);
    }
}
