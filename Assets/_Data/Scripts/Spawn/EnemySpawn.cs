using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : Spawner
{
    private static EnemySpawn instance;
    public static EnemySpawn Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }

    public virtual void DestroyEnemy(Transform obj)
    {
        poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
    }
}
