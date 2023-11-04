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

    [Header("Inventory")]
    private InventoryManager inventory;
    //public int weaponIndex;
    [HideInInspector] public int weaponIconIndex;
    [HideInInspector] public int passiveItemIndex;

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

        inventory = GetComponentInChildren<InventoryManager>();

        currentMaxHp = characterStats.MaxHp;
        currentRecovery = characterStats.Recovery;
        currentSpeed = characterStats.Speed;

        LoadModel(characterStats.Character);
        LoadSkillUI(characterStats.IconAttack, characterStats.IconSpecial);
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
            currentMaxHp += 10;
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

    public void LoadModel(GameObject model)
    {
        // if (weaponIndex >= inventory.weaponsSlots.Count - 1)
        // {
        //     Debug.LogError("Full slot");
        //     return;
        // }
        GameObject spawnModel = Instantiate(model, transform.position, Quaternion.identity);
        spawnModel.transform.SetParent(transform);
        //inventory.AddWeapon(weaponIndex, spawnModel.GetComponent<WeaponController>());
        //weaponIndex++;
    }
    public void LoadSkillUI(Sprite icon1, Sprite icon2)
    {
        inventory.AddUISkill(weaponIconIndex, icon1);
        weaponIconIndex++;
        inventory.AddUISkill(weaponIconIndex, icon2);
        weaponIconIndex++;
    }

    public void SpawnPassiveItem(GameObject passiveItem)
    {
        if (passiveItemIndex >= inventory.passiveItemSlots.Count - 1)
        {
            Debug.LogError("Full slot passive");
            return;
        }
        GameObject spawnPassive = Instantiate(passiveItem, transform.position, Quaternion.identity);
        spawnPassive.transform.SetParent(transform);
        inventory.AddPassiveItem(passiveItemIndex, spawnPassive.GetComponent<PassiveItem>());
        passiveItemIndex++;
    }
}
