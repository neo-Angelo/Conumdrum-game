using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public Inventory Container;


    public void addItem(itemObject _item) {
        bool hasItem = false;

        for (int i = 0; i < Container.Items.Count; i++) {
            if (Container.Items[i].item == _item){
                hasItem = true;
                break;
            }

        }
        if (!hasItem)
        {
            Container.Items.Add(new InventorySlot(_item));
        }

    }
}
[System.Serializable]
public class Inventory {
    public List<InventorySlot> Items = new List<InventorySlot>();

}

[System.Serializable]
public class InventorySlot
{
    public itemObject item;
    public string nameItem;
    public Sprite uiDisplay;
    public int id;
    public InventorySlot(itemObject _item) {
        item = _item;
        nameItem = _item.nameItem;
        uiDisplay = _item.uiDisplay;
        id = _item.id;
    }

}