using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Stats")]
    public CharacterScriptableObjects characterStats;
    public int currentMaxHp;
    [HideInInspector] public int currentRecovery;
    [HideInInspector] public float currentSpeed;
    [Header("Level/Exp")]
    public int experience = 0;
    public int level = 1;
    public int experienceCap;

    [System.Serializable]
    public class LevelRange
    {
        public int startLevel;
        public int endLevel;
        public int experienceCapIncrease;
    }
    public List<LevelRange> levelRanges;

    private void Awake()
    {
        characterStats = CharacterSelector.GetData();
        CharacterSelector.Instance.DestroySingleton();

        //Instantiate(characterStats.Character);

        currentMaxHp = characterStats.MaxHp;
        currentRecovery = characterStats.Recovery;
        currentSpeed = characterStats.Speed;

    }

    private void Start()
    {
        experienceCap = levelRanges[0].experienceCapIncrease; //khoi tao experienceCap tai lv dau tien
        InvokeRepeating("Recovery", 0f, 2f); // tu hoi phuc moi 2s

    }

    public void IncreaseExperience(int amount)
    {
        experience += amount;
        LevelUpChecker();
    }
    private void LevelUpChecker()
    {
        if (experience >= experienceCap)
        {
            level++;
            Debug.Log("Level Up to " + level);
            experience -= experienceCap;

            int experienceCapIncrease = 0;
            foreach (LevelRange range in levelRanges)
            {
                if (level >= range.startLevel && level <= range.endLevel)
                {
                    experienceCapIncrease = range.experienceCapIncrease;
                    break;
                }
            }
            experienceCap += experienceCapIncrease;
        }
    }

    public void TakeDamage(int dmg)
    {
        currentMaxHp -= dmg;
        if (currentMaxHp <= 0)
        {
            PlayerDead();
        }
    }

    private void PlayerDead()
    {
        Debug.LogWarning("You Dead");
    }

    public void RestoreHealth(int amount)
    {
        if (currentMaxHp < characterStats.MaxHp)
        {
            currentMaxHp += amount;

            if (currentMaxHp > characterStats.MaxHp)
            {
                currentMaxHp = characterStats.MaxHp;
            }
        }
    }
    private void Recovery()
    {
        if (currentMaxHp < characterStats.MaxHp)
        {
            currentMaxHp += currentRecovery;

            if (currentMaxHp > characterStats.MaxHp)
            {
                currentMaxHp = characterStats.MaxHp;
            }
        }
    }
}
