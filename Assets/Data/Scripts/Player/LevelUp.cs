using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    protected PlayerStats playerStats;
    protected WeaponController weaponStats;
    private void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        weaponStats = FindObjectOfType<WeaponController>();
    }

    public void LevelUpAttack()
    {
        weaponStats.currDamage += 1;
    }
    public void LevelUpSpeed()
    {
        playerStats.currentSpeed *= 1 + 5 / 100f;

    }
    public void LevelUpAttackSpeed()
    {
        if (weaponStats.hitDelay <= 0.5f)
        {
            return;
        }
        weaponStats.hitDelay *= 1 - 10 / 100f; //giam 10 toc do danh
    }
}
