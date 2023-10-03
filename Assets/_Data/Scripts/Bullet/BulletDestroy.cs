using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : DestroyByDistance
{
    protected override void DestroyObject()
    {
        BulletSpawn.Instance.DestroyBullet(transform.parent);
    }
}
