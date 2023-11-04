using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatBehavior : ThaiBehaviour //thuc chien cast phep,vv...
{
    protected Transform shootPoint;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        shootPoint = GameObject.FindGameObjectWithTag("ShootPoint").transform;
    }
    public void CastFireBall() //cast phep trong animation
    {
        Vector3 spawnPos = shootPoint.transform.position;
        Quaternion rot = shootPoint.transform.rotation;
        Transform bullet = BulletSpawn.Instance.Spawn(spawnPos, rot, 0);
        bullet.gameObject.SetActive(true);
    }
    public void CastBigFireBall() //cast phep trong animation
    {
        Vector3 spawnPos = shootPoint.transform.position;
        Quaternion rot = shootPoint.transform.rotation;
        Transform bullet = BulletSpawn.Instance.Spawn(spawnPos, rot, 1);
        bullet.gameObject.SetActive(true);
    }
}
