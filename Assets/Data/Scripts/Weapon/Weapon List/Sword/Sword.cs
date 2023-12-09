using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : WeaponController
{
    public Transform slashPoint;
    protected float lastHorizontalVector;
    protected Vector3 swordDirection;

    private void FixedUpdate()
    {
        swordDirection = InputManager.Instance.MoveDir;
        if (swordDirection.x != 0)
        {
            lastHorizontalVector = swordDirection.x;
        }

        if (lastHorizontalVector < 0)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -180);
        }
        else
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
        }
    }
    protected override void Attack()
    {
        base.Attack();

        Vector3 spawnPos = slashPoint.transform.position;
        Quaternion rot = slashPoint.transform.rotation;
        Transform bullet = BulletSpawn.Instance.Spawn(spawnPos, rot, 4);
        bullet.gameObject.SetActive(true);
    }
}
