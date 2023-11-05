using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : ThaiBehaviour
{
    protected Rigidbody2D rb;
    private BoxCollider2D box2d;
    protected Transform shootPoint;
    protected Vector3 targetPosition;
    [HideInInspector] public Vector2 moveDir;

    protected PlayerStats playerStats;


    protected override void LoadComponents()
    {
        shootPoint = GameObject.FindGameObjectWithTag("ShootPoint").GetComponent<Transform>();
        playerStats = GetComponent<PlayerStats>();
        LoadCollider();
        LoadRigidbody();
    }

    protected virtual void LoadRigidbody()
    {
        if (rb != null) return;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.freezeRotation = true;
    }

    protected virtual void LoadCollider()
    {
        if (box2d != null) return;
        box2d = GetComponent<BoxCollider2D>();
        this.box2d.isTrigger = false;
    }

    private void FixedUpdate()
    {
        GetMousePos();
        Moving();
    }

    private void GetMousePos()
    {
        targetPosition = InputManager.Instance.MousePos;
        targetPosition.z = 0;
    }

    protected virtual void Moving()
    {
        moveDir = InputManager.Instance.MoveDir;

        //nhin ve huong con chuot
        Vector3 diff = targetPosition - transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        shootPoint.rotation = Quaternion.Euler(0f, 0f, rot_z);

        Vector3 aimDir = Vector3.one;
        if (rot_z > 90 || rot_z < -90)
        {
            aimDir.y = -1f;
        }
        else
        {
            aimDir.y = +1f;
        }
        shootPoint.localScale = aimDir;

        //moving
        rb.velocity = new Vector2(moveDir.x * playerStats.CurrentSpeed, moveDir.y * playerStats.CurrentSpeed);
    }
}
