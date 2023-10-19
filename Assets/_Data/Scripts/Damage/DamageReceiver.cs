using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class DamageReceiver : MonoBehaviour
{
    [SerializeField] protected int hp;
    [SerializeField] protected int hpMax;
    protected bool isDead = false;


    private void OnEnable()
    {
        Reborn();
    }

    public virtual void Reborn()
    {
        hp = hpMax;
        isDead = false;
    }

    public virtual void AddHp(int add)
    {
        hp += add;
        if (hp > hpMax)
        {
            hp = hpMax;
        }
    }

    public virtual void DeductHp(int deduct)
    {
        hp -= deduct;
        if (hp < 0)
        {
            hp = 0;
        }

        if (!CheckIsDead())
        {
            return;
        }
        else
        {
            Kill();
        }

    }

    protected virtual bool CheckIsDead()
    {
        if (!IsDead())
        {
            return isDead = false;
        }

        return isDead = true;
    }

    protected virtual bool IsDead()
    {
        return hp <= 0;
    }

    protected virtual void Kill()
    {
        // for override
    }
}
