using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMagicBehaviour : DamageSender
{
    private WizzardSpecial wizzardSpecial;
    private Vector3 direction = Vector3.right;
    private int pierce;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        wizzardSpecial = GameObject.Find("Player").GetComponentInChildren<WizzardSpecial>();
    }
    private void Start()
    {
        pierce = wizzardSpecial.specialStats.Pierce;
    }
    private void Update()
    {
        MovingForward();
    }
    protected virtual void MovingForward()
    {
        transform.parent.Translate(direction * wizzardSpecial.specialStats.Speed * Time.deltaTime);
    }
    public override void Send(DamageReceiver damageReceiver)
    {
        damageReceiver.DeductHp(wizzardSpecial.CurrDamage);
        DestroyObject();
    }
    protected override void DestroyObject()
    {
        pierce--;
        if (pierce <= 0)
        {
            BulletSpawn.Instance.DeSpawn(transform.parent);
            pierce = wizzardSpecial.specialStats.Pierce;
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
