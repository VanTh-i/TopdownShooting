using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Stats")]
    public CharacterScriptableObjects characterStats;
    private int currentMaxHP;
    [SerializeField] private int currentHp;
    private int currentRecovery;
    private float currentSpeed;

    #region Stat Property
    public int CurrentMaxHP
    {
        get => currentMaxHP;
        set
        {
            currentMaxHP = value;
            if (GameManager.Instance != null)
            {
                GameManager.Instance.maxHPDisplay.text = "" + currentMaxHP;
            }
        }
    }

    public int CurrentHp
    {
        get => currentHp;
        set
        {
            currentHp = value;
            // if (GameManager.Instance != null)
            // {
            //     GameManager.Instance.maxHPDisplay.text = "" + currentHp;
            // }
        }
    }
    public int CurrentRecovery
    {
        get => currentRecovery;
        set
        {
            currentRecovery = value;
            if (GameManager.Instance != null)
            {
                GameManager.Instance.recoveryDisplay.text = "" + currentRecovery;
            }
        }
    }
    public float CurrentSpeed
    {
        get => currentSpeed;
        set
        {
            currentSpeed = value;
            if (GameManager.Instance != null)
            {
                GameManager.Instance.moveSpeedDisplay.text = "" + currentSpeed.ToString("F2");
            }
        }
    }

    #endregion

    [Header("Level/Exp")]
    public int experience = 0;
    public int level = 1;
    public int experienceCap;

    [Header("Inventory")]
    private InventoryManager inventory;
    protected int skillIconIndex;
    protected int passiveItemIndex;
    [HideInInspector] public int auraItemIndex;
    [HideInInspector] public int familiarItemIndex;
    public GameObject[] passiveItemPrefabs;

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

        CurrentMaxHP = characterStats.MaxHp;
        CurrentHp = characterStats.MaxHp;
        CurrentRecovery = characterStats.Recovery;
        CurrentSpeed = characterStats.Speed;

        //player Load
        LoadModel(characterStats.Character);
        LoadSkillUI(characterStats.IconAttack, characterStats.IconSpecial);
    }

    private void Start()
    {
        experienceCap = levelRanges[0].experienceCapIncrease; //khoi tao experienceCap tai lv dau tien

        //GameManager.Instance.maxHPDisplay.text = "" + currentHp;
        //show chi so
        GameManager.Instance.maxHPDisplay.text = "" + currentMaxHP;
        GameManager.Instance.recoveryDisplay.text = "" + currentRecovery;
        GameManager.Instance.moveSpeedDisplay.text = "" + currentSpeed.ToString("F2");
        GameManager.Instance.ResultChosenCharacters(characterStats); //show player da choi khi chet

        InvokeRepeating("Recovery", 0f, 5f); // tu hoi phuc moi 2s

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
            CurrentMaxHP += 10;
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

            GameManager.Instance.StartLevelUp();
        }
    }

    public void TakeDamage(int dmg)
    {
        CurrentHp -= dmg;
        if (CurrentHp <= 0)
        {
            CurrentHp = 0;
            PlayerDead();
        }
    }
    private void PlayerDead()
    {
        if (!GameManager.Instance.isGameOver)
        {
            GameManager.Instance.GameOver();
        }
    }

    public void RestoreHealth(int amount)
    {
        if (CurrentHp < CurrentMaxHP)
        {
            CurrentHp += amount;

            if (CurrentHp > CurrentMaxHP)
            {
                CurrentHp = CurrentMaxHP;
            }
        }
    }
    private void Recovery()
    {
        if (CurrentHp < CurrentMaxHP)
        {
            CurrentHp += CurrentRecovery;

            if (CurrentHp > CurrentMaxHP)
            {
                CurrentHp = CurrentMaxHP;
            }
        }
    }

    public void LoadModel(GameObject model)
    {
        GameObject spawnModel = Instantiate(model, transform.position, Quaternion.identity);
        spawnModel.transform.SetParent(transform);
    }
    public void LoadSkillUI(Sprite icon1, Sprite icon2)
    {
        inventory.AddUISkill(skillIconIndex, icon1);
        skillIconIndex++;
        inventory.AddUISkill(skillIconIndex, icon2);
        skillIconIndex++;
    }

    public void SpawnPassiveItem(int prefabIndex)
    {
        if (passiveItemIndex >= inventory.passiveItemSlots.Count - 1)
        {
            Debug.LogError("Full slot passive");
            return;
        }
        GameObject spawnPassive = Instantiate(passiveItemPrefabs[prefabIndex], transform.position + passiveItemPrefabs[prefabIndex].transform.position, Quaternion.identity);
        spawnPassive.transform.SetParent(transform);
        inventory.AddPassiveItem(passiveItemIndex, spawnPassive.GetComponent<PassiveItem>());

        if (prefabIndex == 0)
        {
            auraItemIndex = passiveItemIndex;
            passiveItemIndex++;
        }
        else if (prefabIndex == 1)
        {
            familiarItemIndex = passiveItemIndex;
            passiveItemIndex++;
        }
    }
}
