using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer : MonoBehaviour
{
    public InventoryObject Inventory;
    public GameObject cameraMain;

    void Start()
    {
        cameraMain.SetActive(true);
    }
    public void PickUpItem(itemObject _item)
    {
        if (_item)
        {
            Inventory.addItem(_item);
        }
    }

    public bool podeUsar(string nome)
    {
        for (int i = 0; i < Inventory.Container.Items.Count; i++)
        {
            if (Inventory.Container.Items[i].nameItem == nome)
            {
                return true;
            }

        }

        return false;
    }

    private void OnApplicationQuit()
    {
        Inventory.Container.Items.Clear();
    }
}
