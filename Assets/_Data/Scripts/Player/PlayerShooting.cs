using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    //protected bool isShooting = false;
    [SerializeField] protected float shootDelay = 0.5f;
    protected float shootTime = 0f;

    private void Update()
    {
        Shooting();
    }

    private void Shooting()
    {
        if (!InputManager.Instance.OnFiring)
        {
            return;
        }
        else if (Time.time >= shootTime + shootDelay) //delay shoot
        {
            Vector3 spawnPos = transform.position;
            Quaternion rot = transform.rotation;
            Transform bullet = BulletSpawn.Instance.Spawn(spawnPos, rot, 0);
            bullet.gameObject.SetActive(true);

            shootTime = Time.time;
        }

    }
}
