using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoving : ThaiBehaviour
{
    protected Transform player;
    [SerializeField] protected float speed = 1f;
    protected Vector3 direction = Vector3.right;

    private void Update()
    {
        MovingForward();
    }

    protected virtual void MovingForward()
    {
        transform.parent.Translate(direction * speed * Time.deltaTime);
    }
    protected override void LoadComponents()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }
}
