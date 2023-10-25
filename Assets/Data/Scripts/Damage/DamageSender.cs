using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : ThaiBehaviour
{
    protected int damage;

    public virtual void Send(Transform obj)
    {
        DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null)
        {
            return;
        }
        Send(damageReceiver);
    }

    public virtual void Send(DamageReceiver damageReceiver)
    {
        damageReceiver.DeductHp(damage);
        DestroyObject();
    }

    protected virtual void DestroyObject()
    {
        BulletSpawn.Instance.DeSpawn(transform.parent);
    }
}
