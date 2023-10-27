using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBehaviour : DamageSender
{
    private WizzardMagic wizzardMagic;
    private Vector3 direction = Vector3.right;
    private int pierce;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        wizzardMagic = GameObject.Find("Player").GetComponentInChildren<WizzardMagic>();
    }
    private void Start()
    {
        pierce = wizzardMagic.weaponStats.Pierce;
    }
    private void Update()
    {
        MovingForward();
    }
    protected virtual void MovingForward()
    {
        transform.parent.Translate(direction * wizzardMagic.weaponStats.Speed * Time.deltaTime);
    }
    public override void Send(DamageReceiver damageReceiver)
    {
        damageReceiver.DeductHp(wizzardMagic.currDamage);
        DestroyObject();
    }
    protected override void DestroyObject()
    {
        pierce--;
        if (pierce <= 0)
        {
            BulletSpawn.Instance.DeSpawn(transform.parent);
            pierce = wizzardMagic.weaponStats.Pierce;
        }
        SpawnExplosion();
    }
    private void OnDisable() //tao ra vu no sau khi dan va cham
    {

    }
    protected virtual void SpawnExplosion()
    {
        Transform explosion = FxSpawn.Instance.Spawn(transform.position, transform.rotation, 1);
        explosion.gameObject.SetActive(true);
    }
}
