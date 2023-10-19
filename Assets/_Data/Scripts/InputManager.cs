using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance { get => instance; }

    private Vector3 mousePos;
    public Vector3 MousePos { get => mousePos; }

    private Vector2 moveDir;
    public Vector2 MoveDir { get => moveDir; }

    // private Vector3 mouseMovePos;
    // public Vector3 MouseMovePos { get => mouseMovePos; }

    private bool onFiring = false;
    public bool OnFiring { get => onFiring; }

    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        GetMouseShoot();
    }
    private void FixedUpdate()
    {
        GetMousePos();
        MoveInput();
        //GetMouseMove();
    }

    protected virtual void GetMousePos()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    protected virtual Vector2 MoveInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        return moveDir = new Vector2(moveX, moveY).normalized;
    }

    // protected virtual void GetMouseMove() //right mouse move
    // {
    //     if (Input.GetKey(KeyCode.Mouse1))
    //     {
    //         mouseMovePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //         Debug.Log(mouseMovePos);
    //     }
    // }

    protected virtual void GetMouseShoot() // shoot
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            onFiring = true;
        }
        else
        {
            onFiring = false;
        }
    }

}
