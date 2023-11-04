using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByDistance : Destroy
{
    public WeaponScriptableObject weaponStats;
    public float maxDistance;
    //protected float distance = 0f;
    protected Camera mainCam;

    protected override void LoadComponents()
    {
        LoadCamera();
        maxDistance = weaponStats.Range;
    }

    protected virtual void LoadCamera()
    {
        if (mainCam != null)
        {
            return;
        }
        mainCam = FindObjectOfType<Camera>();
    }

    protected override bool CanDestroy()
    {
        float distance = Vector3.Distance(transform.position, mainCam.transform.position);
        if (distance >= maxDistance)
        {
            return true;
        }
        return false;
    }
}
