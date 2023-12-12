using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyromancerLamp : WeaponController
{
    protected override void Attack()
    {
        base.Attack();
        Vector3 spawnPos = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
        Quaternion rot = GetRandomShootPoint();
        Transform bullet = BulletSpawn.Instance.Spawn(spawnPos, rot, 0);
        bullet.gameObject.SetActive(true);
    }
    private Quaternion GetRandomShootPoint()
    {
        float randomDir = Random.Range(0f, 360f);
        return Quaternion.Euler(0, 0, randomDir);
    }
}
