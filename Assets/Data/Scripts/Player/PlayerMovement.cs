using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : ThaiBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D box2d;
    protected Transform shootPoint;
    protected Vector3 targetPosition;
    [HideInInspector] public Vector2 moveDir;

    [Header("Weapon Stats")]
    public CharacterScriptableObjects characterStats;


    protected override void LoadComponents()
    {
        shootPoint = GameObject.FindGameObjectWithTag("ShootPoint").GetComponent<Transform>();
        LoadCollider();
        LoadRigidbody();
    }

    private void LoadRigidbody()
    {
        if (rb != null) return;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.freezeRotation = true;
    }

    private void LoadCollider()
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

    private void Moving()
    {
        moveDir = InputManager.Instance.MoveDir;

        //look at mouse position
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
        rb.velocity = new Vector2(moveDir.x * characterStats.Speed, moveDir.y * characterStats.Speed);
    }
}
