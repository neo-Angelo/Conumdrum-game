using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class DisplayInventory : MonoBehaviour
{
    public GameObject descri;
    public GameObject fotin;
    public GameObject nome;
    public GameObject inventoryPrefab;
    public InventoryObject inventory;
    public int X_START;
    public int Y_START;
    public int X_SPACE_BETWEEN_ITEM;
    public int NUMBER_OF_COLUMN;
    public int Y_SPACE_BETWEEN_ITEM;

    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }

    public void CreateDisplay() { 
        for(int i = 0; i < inventory.Container.Items.Count; i++)
        {
            var obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);
            obj.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventory.Container.Items[i].uiDisplay;
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container.Items[i].nameItem;
            itemsDisplayed.Add(inventory.Container.Items[i], obj);

            int index = i; // Capture the index variable for the lambda expression
            AddEvent(obj, EventTriggerType.PointerClick, (eventData) => OnItemClick(index));
        }


    }
    public Vector3 GetPosition(int i)
    {
       
        return new Vector3(X_START + ( X_SPACE_BETWEEN_ITEM * (i % NUMBER_OF_COLUMN)),Y_START + ((-Y_SPACE_BETWEEN_ITEM *(i/NUMBER_OF_COLUMN))),0f);

    }
    public void UpdateDisplay() {
        for (int i = 0; i < inventory.Container.Items.Count; i++)
        {
            if (!itemsDisplayed.ContainsKey(inventory.Container.Items[i]))
            {
                var obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);
                obj.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventory.Container.Items[i].uiDisplay;
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container.Items[i].nameItem;
                itemsDisplayed.Add(inventory.Container.Items[i], obj);


                int index = i; // Capture the index variable for the lambda expression
                AddEvent(obj, EventTriggerType.PointerClick, (eventData) => OnItemClick(index));
            }
        }


    }

    private void AddEvent(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();

        if (trigger == null)
        {
            trigger = obj.AddComponent<EventTrigger>();
        }

        var eventTrigger = new EventTrigger.Entry();
        eventTrigger.eventID = type;
        eventTrigger.callback.AddListener(action);
        trigger.triggers.Add(eventTrigger);
    }

    public void OnItemClick(int index)
    {

        Debug.Log("clickado");
        string itemDescricao = inventory.Container.Items[index].item.description;
        string itemName = inventory.Container.Items[index].nameItem;
        Debug.Log("Clicked Item: " + itemDescricao);
        
        descri.GetComponent<TextMeshProUGUI>().text = itemDescricao;
        nome.GetComponent<TextMeshProUGUI>().text = itemName;

        Image imageComponent = fotin.GetComponent<Image>();
        imageComponent.sprite = inventory.Container.Items[index].uiDisplay;
        imageComponent.color = Color.white;

    }



}
