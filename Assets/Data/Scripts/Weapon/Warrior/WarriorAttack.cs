using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorAttack : WeaponController
{
    protected Animator animator;
    protected Transform attackPoint;
    public LayerMask enemyLayer;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        animator = GetComponent<Animator>();
        attackPoint = GameObject.FindGameObjectWithTag("ShootPoint").transform;
    }

    protected override void Attack()
    {
        if (!InputManager.Instance.OnFiring)
        {
            return;
        }
        base.Attack();
        animator.SetTrigger("Attack");
        SpawnExplosion();

    }

    public void DealingDamage()
    {
        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(attackPoint.position, currRange, enemyLayer);
        foreach (Collider2D enemy in hitEnemys)
        {
            float distance = Vector2.Distance(attackPoint.position, enemy.transform.position);

            if (distance <= currRange)
            {
                Debug.Log("Hit Enemy");
                DamageReceiver damageReceiver = enemy.GetComponent<DamageReceiver>();
                if (damageReceiver != null)
                {
                    damageReceiver.DeductHp(currDamage);
                }
            }
        }
    }

    protected virtual void SpawnExplosion()
    {
        Transform explosion = FxSpawn.Instance.Spawn(transform.position, transform.rotation, 2);
        explosion.gameObject.SetActive(true);
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, currRange);
    }
}
