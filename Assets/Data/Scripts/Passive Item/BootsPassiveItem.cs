using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootsPassiveItem : PassiveItem
{
    protected override void ApplyModifier()
    {
        base.ApplyModifier();
        playerStats.CurrentSpeed *= 1 + passiveItemData.Multipler / 100f;
    }
}
