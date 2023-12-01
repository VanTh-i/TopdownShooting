using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class InventoryManager : MonoBehaviour
{
    public List<Image> skillUISlots = new List<Image>();
    public List<PassiveItem> passiveItemSlots = new List<PassiveItem>();
    public int[] passiveItemLevels = new int[6];

    public void AddUISkill(int slotIndex, Sprite icon)
    {
        skillUISlots[slotIndex].sprite = icon;
    }

    public void AddPassiveItem(int slotIndex, PassiveItem passiveItem)
    {
        passiveItemSlots[slotIndex] = passiveItem;
        passiveItemLevels[slotIndex] = passiveItem.passiveItemData.Level;
    }

    public void LevelUpAuraPassiveItem(PlayerStats playerStats)
    {
        if (passiveItemSlots.Count > playerStats.auraItemIndex)
        {
            PassiveItem passiveItem = passiveItemSlots[playerStats.auraItemIndex];
            if (!passiveItem.passiveItemData.NextLevelPrefab)
            {
                Debug.LogWarning("level up is max");
                return;
            }
            GameObject upgradePassive = Instantiate(passiveItem.passiveItemData.NextLevelPrefab, transform.position + passiveItem.passiveItemData.NextLevelPrefab.transform.position, Quaternion.identity);
            upgradePassive.transform.SetParent(transform.parent);
            AddPassiveItem(playerStats.auraItemIndex, upgradePassive.GetComponent<PassiveItem>());
            Destroy(passiveItem.gameObject);
            passiveItemLevels[playerStats.auraItemIndex] = upgradePassive.GetComponent<PassiveItem>().passiveItemData.Level;
        }

    }
    public void LevelUpFamiliarPassiveItem(PlayerStats playerStats)
    {
        if (passiveItemSlots.Count > playerStats.familiarItemIndex)
        {
            PassiveItem passiveItem = passiveItemSlots[playerStats.familiarItemIndex];
            if (!passiveItem.passiveItemData.NextLevelPrefab)
            {
                Debug.LogWarning("level up is max");
                return;
            }
            GameObject upgradePassive = Instantiate(passiveItem.passiveItemData.NextLevelPrefab, transform.position + passiveItem.passiveItemData.NextLevelPrefab.transform.position, Quaternion.identity);
            upgradePassive.transform.SetParent(transform.parent);
            AddPassiveItem(playerStats.familiarItemIndex, upgradePassive.GetComponent<PassiveItem>());
            Destroy(passiveItem.gameObject);
            passiveItemLevels[playerStats.familiarItemIndex] = upgradePassive.GetComponent<PassiveItem>().passiveItemData.Level;
        }

    }

    private void ApplyUpgradeOptions()
    {


    }

}
