using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//[RequireComponent(typeof(Collider2D))]

public class DamageReceiver : MonoBehaviour
{
    [SerializeField] protected int hp;
    protected int currentHp;
    protected bool isDead = false;

    protected virtual void Awake()
    {

    }

    protected virtual void OnEnable()
    {
        Reborn();
    }

    public virtual void Reborn()
    {
        hp = currentHp;
        isDead = false;
    }

    public virtual void AddHp(int add)
    {
        hp += add;
        if (hp > currentHp)
        {
            hp = currentHp;
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
