using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : ThaiBehaviour
{
    private Rigidbody2D rb;
    protected Transform gunDir;
    protected Vector3 targetPosition;
    [HideInInspector] public Vector2 moveDir;
    [SerializeField] protected float speed = 1f;

    protected override void LoadComponents()
    {
        gunDir = GameObject.Find("Gun").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
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
        gunDir.rotation = Quaternion.Euler(0f, 0f, rot_z);

        Vector3 aimDir = Vector3.one;
        if (rot_z > 90 || rot_z < -90)
        {
            aimDir.y = -1f;
        }
        else
        {
            aimDir.y = +1f;
        }
        gunDir.localScale = aimDir;

        //moving
        rb.velocity = new Vector2(moveDir.x * speed, moveDir.y * speed);
    }
}
