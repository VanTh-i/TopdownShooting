using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirect : ThaiBehaviour
{
    protected Vector3 targetPosition;

    private void FixedUpdate()
    {
        GetMousePos();
        PlayerDirection();
    }
    private void GetMousePos()
    {
        targetPosition = InputManager.Instance.MousePos;
        targetPosition.z = 0;
    }
    private void PlayerDirection()
    {
        Vector3 diff = targetPosition - transform.position;
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        Vector3 aimDir = Vector3.one;
        if (rot_z > 90 || rot_z < -90)
        {
            aimDir.x = 1f;
        }
        else
        {
            aimDir.x = -1f;
        }
        transform.localScale = aimDir;
    }
}
