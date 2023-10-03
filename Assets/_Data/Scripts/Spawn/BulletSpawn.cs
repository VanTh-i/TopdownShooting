using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : Spawner
{
    private static BulletSpawn instance;
    public static BulletSpawn Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }

    public virtual void DestroyBullet(Transform obj)
    {
        poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
    }

}
