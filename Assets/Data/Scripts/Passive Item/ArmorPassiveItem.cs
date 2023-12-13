using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPassiveItem : PassiveItem
{
    protected override void ApplyModifier()
    {
        playerStats.CurrentArmor = (int)passiveItemData.Multipler;
    }
}
