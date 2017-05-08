using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : vnc.Utilities.SingletonMonoBehaviour<InventoryManager>
{
    #region Singleton
    private void Awake()
    {
        CreateSingleton();
    }

    public override void CreateSingleton()
    {
        Singleton = this;
    }
    #endregion

    List<Item> Items;

    [Header("Refereances")]
    public ItemButton ItemPrefab;
    public Image Inventory;
    public LayoutGroup InventoryLayout;

    static InteractiveObject _currentInteraction;

    void Start()
    {
        Items = new List<Item>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            if (Inventory.gameObject.activeSelf)
            {
                Hide();
            }
            else
            {
                Show();
            }
        }
    }

    public static void Add(Item item)
    {
        var itemBtn = Instantiate(Singleton.ItemPrefab);
        itemBtn.item = item;
        itemBtn.GetComponent<Image>().sprite = item.Icon;
        itemBtn.transform.SetParent(Singleton.InventoryLayout.transform);
    }

    public static void Combine(InteractiveObject interactiveObj)
    {
        _currentInteraction = interactiveObj;
        Show();
    }

    /// <summary>
    /// Try combining an item with an interactive object
    /// </summary>
    /// <param name="item">Item to be combined</param>
    /// <returns>If the combination worked</returns>
    public static bool TryCombination(Item item)
    {
        Hide();
        return _currentInteraction.TrySatisfyCondition(item.Key);
    }

    static void Show()
    {
        Singleton.Inventory.gameObject.SetActive(true);
        GameManager.FirstPersonMode = false;
    }

    static void Hide()
    {
        Singleton.Inventory.gameObject.SetActive(false);
        GameManager.FirstPersonMode = true;
    }
}
