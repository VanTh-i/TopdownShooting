using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : ThaiBehaviour
{
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjs;
    protected Transform poolHolder;

    protected override void LoadComponents()
    {
        LoadPrefabs();
        LoadPoolHolder();
    }

    protected virtual void LoadPrefabs()
    {
        if (prefabs.Count > 0)
        {
            return;
        }

        Transform prefabObj = transform.Find("Prefabs");
        foreach (Transform prefab in prefabObj)
        {
            prefabs.Add(prefab);
        }

        HidePrefabs();
    }

    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    protected virtual void LoadPoolHolder()
    {
        if (poolHolder != null)
        {
            return;
        }
        poolHolder = transform.Find("Pool");
    }
    // public virtual void DestroyBullet(Transform obj)
    // {
    //     poolObjs.Add(obj);
    //     obj.gameObject.SetActive(false);
    // }

    public virtual Transform Spawn(Vector3 spawnPos, Quaternion rotation, int prefabIndex)
    {
        Transform prefab = this.prefabs[prefabIndex];
        Transform bullet = GetObjectFromPool(prefab);
        bullet.SetPositionAndRotation(spawnPos, rotation);
        bullet.parent = poolHolder;
        return bullet;
    }

    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        foreach (Transform poolObj in poolObjs)
        {
            if (poolObj.name == prefab.name)
            {
                poolObjs.Remove(poolObj);
                return poolObj;
            }
        }

        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }
}
