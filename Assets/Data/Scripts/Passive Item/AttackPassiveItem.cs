using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPassiveItem : PassiveItem
{
    protected override void ApplyModifier()
    {
        base.ApplyModifier();
        weaponStats.CurrDamage *= (int)(1 + passiveItemData.Multipler / 100f);
    }

}
