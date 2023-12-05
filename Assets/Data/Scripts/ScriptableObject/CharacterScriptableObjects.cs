using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterScriptableObjects", menuName = "ScriptableObject/Character")]

public class CharacterScriptableObjects : ScriptableObject
{
    [SerializeField]
    private new string name;
    public string Name { get => name; private set => name = value; }

    [SerializeField]
    private Sprite characterIcon;
    public Sprite CharacterIcon { get => characterIcon; private set => characterIcon = value; }

    [SerializeField]
    private GameObject character;
    public GameObject Character { get => character; private set => character = value; }

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

    [SerializeField] private Sprite iconAttack;
    public Sprite IconAttack { get => iconAttack; private set => iconAttack = value; }

    [SerializeField] private Sprite iconSpecial;
    public Sprite IconSpecial { get => iconSpecial; private set => iconSpecial = value; }
}
