using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : ThaiBehaviour
{
    protected Transform target;
    [SerializeField] protected float speed;

    protected override void LoadComponents()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        this.speed = 5f;
    }

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
