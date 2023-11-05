using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraPassiveItem : MonoBehaviour
{
    public float rotationSpeed;

    void Update()
    {
        transform.RotateAround(transform.parent.position, Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
