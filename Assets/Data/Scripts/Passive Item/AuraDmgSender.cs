using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraDmgSender : DamageSender
{
    public new int damage;
    public override void Send(DamageReceiver damageReceiver)
    {
        damageReceiver.DeductHp(this.damage);
    }

}
