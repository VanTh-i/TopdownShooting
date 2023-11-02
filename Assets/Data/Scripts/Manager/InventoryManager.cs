using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryManager : MonoBehaviour
{
    //public List<WeaponController> weaponsSlots = new List<WeaponController>(2);
    public List<Image> skillUISlots = new List<Image>(2);

    public List<PassiveItem> passiveItemSlots = new List<PassiveItem>(6);
    public int[] passiveItemLevels = new int[6];

    // public void AddWeapon(int slotIndex, WeaponController weapon)
    // {
    //     weaponsSlots[slotIndex] = weapon;
    // }

    public void AddUISkill(int slotIndex, Sprite icon)
    {
        skillUISlots[slotIndex].sprite = icon;
    }

    public void AddPassiveItem(int slotIndex, PassiveItem passiveItem)
    {
        passiveItemSlots[slotIndex] = passiveItem;
        passiveItemLevels[slotIndex] = passiveItem.passiveItemData.Level;
    }

    public void LevelUpWeapon(int slotIndex)
    {

    }

    public void LevelUpPassiveItem(int slotIndex)
    {
        if (passiveItemSlots.Count > slotIndex)
        {
            PassiveItem passiveItem = passiveItemSlots[slotIndex];
            if (!passiveItem.passiveItemData.NextLevelPrefab)
            {
                Debug.LogWarning("level up is max");
                return;
            }
            GameObject upgradePassive = Instantiate(passiveItem.passiveItemData.NextLevelPrefab, transform.position, Quaternion.identity);
            upgradePassive.transform.SetParent(transform.parent);
            AddPassiveItem(slotIndex, upgradePassive.GetComponent<PassiveItem>());
            Destroy(passiveItem.gameObject);
            passiveItemLevels[slotIndex] = upgradePassive.GetComponent<PassiveItem>().passiveItemData.Level;
        }

    }

}
