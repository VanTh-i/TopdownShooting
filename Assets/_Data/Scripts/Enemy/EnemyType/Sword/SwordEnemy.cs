using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEnemy : EnemyMovement
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.attackRange = 2;
    }

}
