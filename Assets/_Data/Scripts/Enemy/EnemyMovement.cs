using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : ObjectMoving
{
    [SerializeField] protected int attackRange;
    protected override void MovingForward()
    {
        transform.LookAt(player);

        if (Vector3.Distance(transform.parent.position, player.position) >= attackRange)
        {
            transform.parent.position += transform.forward * speed * Time.deltaTime;
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

}
