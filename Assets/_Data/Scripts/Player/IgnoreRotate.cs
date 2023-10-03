using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreRotate : MonoBehaviour
{
    private Quaternion parentRotation;
    void Start()
    {
        parentRotation = transform.parent.rotation;
    }

    void Update()
    {
        transform.rotation = Quaternion.Inverse(transform.parent.rotation) * parentRotation * transform.rotation;
        parentRotation = transform.parent.rotation;
    }
}
