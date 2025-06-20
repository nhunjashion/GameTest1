using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : Popup
{
    [SerializeField] InventorySlot inventorySlotPrefab;
    [SerializeField] Transform itemGroup;
    [SerializeField] List<InventorySlot> inventorySlots;
    [SerializeField] int inventorySlotCount = 50;
    private void Start()
    {
        SetIventoryItemData();
    }

    public void SetIventoryItemData()
    {
        ClearDara();

        for(int i = 0; i < inventorySlotCount; i++)
        {
            InventorySlot newItem = Instantiate(inventorySlotPrefab, this.itemGroup);
        }

/*        foreach (var item in buffShow)
        {
            int temp = i++;
            BuffItem newItem = Instantiate(buffItemPrefab, this.buffGroup);
            newItem.SetData(item);
            listBuffButton.Add(newItem);
            newItem.selectBuffButton.onClick.AddListener(() =>
            {
                BuffSelect(newItem, temp);
            });
        }*/
    }

    public void ClearDara()
    {
        inventorySlots.Clear();
        for (int i = 0; i < itemGroup.childCount; i++)
        {
            Destroy(itemGroup.GetChild(i).gameObject);
        }
    }
}
