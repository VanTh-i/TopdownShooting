using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    [Header("WEAPON")]
    public List<WeaponController> listWeaponSlots = new List<WeaponController>(6);
    public int[] weaponLevels = new int[6];
    public List<Image> weaponUISlots = new List<Image>(6);

    [Header("PASSIVE ITEM")]
    public List<PassiveItem> listPassiveItemSlots = new List<PassiveItem>(6);
    public int[] passiveItemLevels = new int[6];
    public List<Image> passiveItemUiSlots = new List<Image>(6);

    public void AddWeapon(int slotIndex, WeaponController weapon)
    {
        listWeaponSlots[slotIndex] = weapon;
        weaponLevels[slotIndex] = weapon.weaponStats.Level;
        weaponUISlots[slotIndex].enabled = true;
        weaponUISlots[slotIndex].sprite = weapon.weaponStats.Icon;
    }

    public void AddPassiveItem(int slotIndex, PassiveItem passiveItem)
    {
        listPassiveItemSlots[slotIndex] = passiveItem;
        passiveItemLevels[slotIndex] = passiveItem.passiveItemData.Level;
        passiveItemUiSlots[slotIndex].enabled = true;
        passiveItemUiSlots[slotIndex].sprite = passiveItem.passiveItemData.Icon;
    }

    public void LevelUpWeapon(int slotIndex)
    {
        if (listWeaponSlots.Count > slotIndex)
        {
            WeaponController weapon = listWeaponSlots[slotIndex];
            if (!weapon.weaponStats.NextLevelPrefab)
            {
                Debug.LogWarning(" no next lv for " + weapon.name);
                return;
            }
            GameObject upgradeWeapon = Instantiate(weapon.weaponStats.NextLevelPrefab, transform.position, Quaternion.identity);
            upgradeWeapon.transform.SetParent(transform.parent);
            AddWeapon(slotIndex, upgradeWeapon.GetComponent<WeaponController>());
            Destroy(weapon.gameObject);
            weaponLevels[slotIndex] = upgradeWeapon.GetComponent<WeaponController>().weaponStats.Level;
        }
    }
    public void LevelUpPassiveItem(int slotIndex)
    {
        if (listPassiveItemSlots.Count > slotIndex)
        {
            PassiveItem passiveItem = listPassiveItemSlots[slotIndex];
            if (!passiveItem.passiveItemData.NextLevelPrefab)
            {
                Debug.LogWarning(" no next lv for " + passiveItem.name);
                return;
            }
            GameObject upgradePassiveItem = Instantiate(passiveItem.passiveItemData.NextLevelPrefab, transform.position, Quaternion.identity);
            upgradePassiveItem.transform.SetParent(transform.parent);
            AddPassiveItem(slotIndex, upgradePassiveItem.GetComponent<PassiveItem>());
            Destroy(passiveItem.gameObject);
            passiveItemLevels[slotIndex] = upgradePassiveItem.GetComponent<PassiveItem>().passiveItemData.Level;
        }
    }


    //
    // public List<Image> skillUISlots = new List<Image>();
    // public List<PassiveItem> passiveItemSlots = new List<PassiveItem>();
    // //public int[] passiveItemLevels = new int[6];

    // public void AddUISkill(int slotIndex, Sprite icon)
    // {
    //     skillUISlots[slotIndex].sprite = icon;
    // }

    // public void AddPassiveItem(int slotIndex, PassiveItem passiveItem)
    // {
    //     passiveItemSlots[slotIndex] = passiveItem;
    //     passiveItemLevels[slotIndex] = passiveItem.passiveItemData.Level;
    // }

    // public void LevelUpAuraPassiveItem(PlayerStats playerStats)
    // {
    //     if (passiveItemSlots.Count > playerStats.auraItemIndex)
    //     {
    //         PassiveItem passiveItem = passiveItemSlots[playerStats.auraItemIndex];
    //         if (!passiveItem.passiveItemData.NextLevelPrefab)
    //         {
    //             Debug.LogWarning("level up is max");
    //             return;
    //         }
    //         GameObject upgradePassive = Instantiate(passiveItem.passiveItemData.NextLevelPrefab, transform.position + passiveItem.passiveItemData.NextLevelPrefab.transform.position, Quaternion.identity);
    //         upgradePassive.transform.SetParent(transform.parent);
    //         AddPassiveItem(playerStats.auraItemIndex, upgradePassive.GetComponent<PassiveItem>());
    //         Destroy(passiveItem.gameObject);
    //         passiveItemLevels[playerStats.auraItemIndex] = upgradePassive.GetComponent<PassiveItem>().passiveItemData.Level;
    //     }

    // }
    // public void LevelUpFamiliarPassiveItem(PlayerStats playerStats)
    // {
    //     if (passiveItemSlots.Count > playerStats.familiarItemIndex)
    //     {
    //         PassiveItem passiveItem = passiveItemSlots[playerStats.familiarItemIndex];
    //         if (!passiveItem.passiveItemData.NextLevelPrefab)
    //         {
    //             Debug.LogWarning("level up is max");
    //             return;
    //         }
    //         GameObject upgradePassive = Instantiate(passiveItem.passiveItemData.NextLevelPrefab, transform.position + passiveItem.passiveItemData.NextLevelPrefab.transform.position, Quaternion.identity);
    //         upgradePassive.transform.SetParent(transform.parent);
    //         AddPassiveItem(playerStats.familiarItemIndex, upgradePassive.GetComponent<PassiveItem>());
    //         Destroy(passiveItem.gameObject);
    //         passiveItemLevels[playerStats.familiarItemIndex] = upgradePassive.GetComponent<PassiveItem>().passiveItemData.Level;
    //     }

    // }

    private void ApplyUpgradeOptions()
    {


    }

}
