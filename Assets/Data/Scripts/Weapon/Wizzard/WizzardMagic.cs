using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizzardMagic : WeaponController
{
    protected Animator animator;
    protected Transform shootPoint;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        animator = GetComponent<Animator>();
        shootPoint = GameObject.FindGameObjectWithTag("ShootPoint").transform;
    }
    protected override void Attack()
    {
        if (!InputManager.Instance.OnFiring)
        {
            return;
        }
        base.Attack();
        animator.SetTrigger("Attack");
    }

    public void CastFireBall() //cast phep trong animation
    {
        Vector3 spawnPos = shootPoint.transform.position;
        Quaternion rot = shootPoint.transform.rotation;
        Transform bullet = BulletSpawn.Instance.Spawn(spawnPos, rot, 0);
        bullet.gameObject.SetActive(true);
    }
}
