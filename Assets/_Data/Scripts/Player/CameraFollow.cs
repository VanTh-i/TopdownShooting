using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : ThaiBehaviour
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float speed;

    private void FixedUpdate()
    {
        FollowTarget();
    }
    protected virtual void FollowTarget()
    {
        if (target == null)
        {
            return;
        }
        transform.position = Vector3.Lerp(transform.position, target.position, Time.fixedDeltaTime * speed);
    }
}
