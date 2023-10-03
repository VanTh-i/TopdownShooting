using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    protected Vector3 targetPosition;
    protected Vector3 movePosition;
    [SerializeField] protected float speed = 1f;

    private void FixedUpdate()
    {
        GetMousePos();
        Moving();
    }

    private void GetMousePos()
    {
        targetPosition = InputManager.Instance.MousePos;
        targetPosition.z = 0;
        
        movePosition = InputManager.Instance.MouseMovePos;
        movePosition.z = 0;
    }

    private void Moving()
    {
        //look at mouse position
        Vector3 diff = targetPosition - transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z);

        //moving
        Vector3 newPos = Vector3.Lerp(transform.parent.position, movePosition, speed * Time.fixedDeltaTime);
        transform.parent.position = newPos;
    }
}
