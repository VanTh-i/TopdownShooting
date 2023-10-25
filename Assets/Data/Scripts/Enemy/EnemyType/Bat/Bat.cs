using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : EnemyMovement
{
    private float collisionCooldown = 1f;
    private float lastCollisionTime = 0f;

    protected override void Action()
    {
        base.Action();
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (Time.time - lastCollisionTime >= collisionCooldown)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("get hit");
                PlayerStats player = other.gameObject.GetComponent<PlayerStats>();
                player.TakeDamage(currentDamage);
                lastCollisionTime = Time.time;
            }
        }
    }
}
