using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : ThaiBehaviour
{
    public EnemyScriptableObject enemyStats;
    protected int currentDamage;
    protected float currentSpeed;
    protected int currentAttackRange;

    protected Transform player;
    protected Transform enemyDir;

    protected override void Awake()
    {
        base.Awake();
        currentDamage = enemyStats.Damage;
        currentSpeed = enemyStats.Speed;
        currentAttackRange = enemyStats.AttackRange;
    }
    protected override void LoadComponents()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        enemyDir = transform.parent.GetComponent<Transform>();
    }

    private void Update()
    {
        MovingForward();
    }
    private void FixedUpdate()
    {
        LookPlayer();
    }

    protected virtual void MovingForward()
    {
        transform.LookAt(player);

        if (Vector3.Distance(transform.parent.position, player.position) >= currentAttackRange)
        {
            transform.parent.position += transform.forward * currentSpeed * Time.deltaTime;
        }
        else
        {
            Action();
        }
    }
    protected virtual void Action()
    {
        // for override
    }

    protected virtual void LookPlayer()
    {
        Vector3 diff = player.position - transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        Vector3 aimDir = Vector3.one;
        if (rot_z > 90 || rot_z < -90)
        {
            aimDir.x = -1f;
        }
        else
        {
            aimDir.x = +1f;
        }
        enemyDir.localScale = aimDir;
    }

}
