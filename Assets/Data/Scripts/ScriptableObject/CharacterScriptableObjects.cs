using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterScriptableObjects", menuName = "ScriptableObject/Character")]

public class CharacterScriptableObjects : ScriptableObject
{
    [SerializeField]
    private GameObject startingWeapon;
    public GameObject StartingWeapon { get => startingWeapon; private set => startingWeapon = value; }

    [SerializeField]
    private int maxHp;
    public int MaxHp { get => maxHp; private set => maxHp = value; }

    [SerializeField]
    private int recovery;
    public int Recovery { get => recovery; private set => recovery = value; }

    [SerializeField]
    private float speed;
    public float Speed { get => speed; private set => speed = value; }
}
