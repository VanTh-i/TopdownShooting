using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : ThaiBehaviour
{
    protected EnemyStats enemyStats;

    protected Transform player;
    protected Transform enemyDir;

    protected override void LoadComponents()
    {
        enemyStats = GetComponentInParent<EnemyStats>();
        enemyDir = transform.parent.GetComponent<Transform>();
        player = FindPlayer.GetPlayer();
        if (player == null)
        {
            Debug.LogError("Can not find player");
        }
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

        if (Vector3.Distance(transform.parent.position, player.position) >= enemyStats.currentAttackRange)
        {
            transform.parent.position += transform.forward * enemyStats.currentSpeed * Time.deltaTime;
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
