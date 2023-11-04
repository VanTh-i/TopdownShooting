using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponScriptableObject", menuName = "ScriptableObject/Weapon")]
public class WeaponScriptableObject : ScriptableObject
{
    [SerializeField] private int damage;
    public int Damage { get => damage; private set => damage = value; }

    [SerializeField] private float speed;
    public float Speed { get => speed; private set => speed = value; }

    [SerializeField] private float hitDelay; //delay don danh
    public float HitDelay { get => hitDelay; private set => hitDelay = value; }

    [SerializeField] private int pierce; // dam xuyen ke thu
    public int Pierce { get => pierce; private set => pierce = value; }

    [SerializeField] private float range;
    public float Range { get => range; private set => range = value; }
}
