using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveItem : ThaiBehaviour
{
    public PassiveItemScriptableObject passiveItemData;

    protected virtual void Start()
    {
        ApplyModifier();
    }
    protected virtual void ApplyModifier()
    {

    }
}
