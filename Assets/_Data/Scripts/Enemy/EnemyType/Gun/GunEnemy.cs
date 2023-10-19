using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEnemy : EnemyMovement
{
    private void FixedUpdate()
    {
        LookPlayer();
    }
    protected virtual void LookPlayer()
    {
        Vector3 diff = player.position - transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z);
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        this.attackRange = 5;
    }
}
