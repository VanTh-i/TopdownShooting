using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizzardMagic : WeaponController
{
    public Animator animator;
    protected override void Attack()
    {
        if (!InputManager.Instance.OnFiring)
        {
            return;
        }
        base.Attack();
        animator.SetTrigger("Attack");


    }

    public void CastFireBall()
    {
        Vector3 spawnPos = transform.position;
        Quaternion rot = transform.rotation;
        Transform bullet = BulletSpawn.Instance.Spawn(spawnPos, rot, 0);
        bullet.gameObject.SetActive(true);
    }
}
