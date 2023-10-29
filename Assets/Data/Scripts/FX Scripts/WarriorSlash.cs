using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorSlash : DestroyByTime
{
    private Transform player;
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        transform.parent.position = player.position;
    }
    protected override void DestroyObject()
    {
        FxSpawn.Instance.DeSpawn(transform.parent);
    }
}
