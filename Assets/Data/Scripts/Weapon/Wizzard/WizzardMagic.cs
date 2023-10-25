using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizzardMagic : WeaponController
{
    protected override void Attack()
    {
        if (!InputManager.Instance.OnFiring)
        {
            return;
        }
        base.Attack();
        Vector3 spawnPos = transform.position;
        Quaternion rot = transform.rotation;
        Transform bullet = BulletSpawn.Instance.Spawn(spawnPos, rot, 0);
        bullet.gameObject.SetActive(true);
    }
}
