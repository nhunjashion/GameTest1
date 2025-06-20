using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Inventory/ItemData", order = 1)]
public class ItemData : ScriptableObject
{

    public GameItem item;
    public Sprite icon;

}
