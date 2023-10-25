using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRateManager : ThaiBehaviour
{
    protected Transform poolHolder;

    [System.Serializable]
    public class Drop
    {
        public string name;
        public GameObject itemPrefab;
        public float dropRate;
    }
    public List<Drop> drops;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        poolHolder = GameObject.Find("Item Drop").GetComponent<Transform>();
    }

    protected virtual void OnDisable()
    {

    }
    protected virtual void OnDestroy()
    {

    }
}
