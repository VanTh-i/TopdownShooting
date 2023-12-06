using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PassiveItemScriptableObject", menuName = "ScriptableObject/PassiveItem")]

public class PassiveItemScriptableObject : ScriptableObject
{
    [SerializeField] private Sprite icon;
    public Sprite Icon { get => icon; private set => icon = value; }

    [SerializeField]
    private float multipler; // he so buff cho 1 cai buff gi day
    public float Multipler { get => multipler; private set => multipler = value; }

    [SerializeField]
    private int level;
    public int Level { get => level; private set => level = value; }

    [SerializeField]
    private GameObject nextLevelPrefab;
    public GameObject NextLevelPrefab { get => nextLevelPrefab; private set => nextLevelPrefab = value; }

}
