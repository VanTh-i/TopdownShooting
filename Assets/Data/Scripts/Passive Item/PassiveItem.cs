using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveItem : MonoBehaviour
{
    protected PlayerStats playerStats;
    protected WeaponController weaponStats;
    public PassiveItemScriptableObject passiveItemData;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        weaponStats = FindObjectOfType<WeaponController>();
        ApplyModifier();
    }
    protected virtual void ApplyModifier()
    {

    }
}
