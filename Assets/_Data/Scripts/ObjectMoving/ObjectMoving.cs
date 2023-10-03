using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectMoving : MonoBehaviour
{
    [SerializeField] protected float speed = 1f;
    protected Vector3 direction = Vector3.right;
    
    private void Update()
    {
        transform.parent.Translate(direction * speed * Time.deltaTime);
    }
}
