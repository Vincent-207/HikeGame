using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    [SerializeField] Transform inventoryRect;
    public ItemSO[] items;
    
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }
    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
            return;
        }

        instance = this;
        // Debug.Log("Saving this thing!");
        DontDestroyOnLoad(this);
    }
    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        Start();
    }
    void Start()
    {
        
        inventoryRect = InventoryUI.instance.transform;
        PopulateInventoryBar();
        // PrintArray();
    }

    void PrintArray()
    {
        Debug.Log("Printing inventory array!");
        if(items == null)
        {
            Debug.Log("Array is null, returning!");
            return;
        }

        foreach(ItemSO item in items)
        {
            Debug.Log("Item: " + item.inventoryGameobject.name);
        }
    }
    public void AddItem(ItemSO item)
    {
       /*  if(InventoryUI.instance == null) Debug.LogWarning("Inv rect instance is null!");
        else Debug.Log("inv rect instance is not null!");
        Debug.Log("inv rect name: " + InventoryUI.instance.gameObject.name);
        if(InventoryUI.instance.transform == null) Debug.LogWarning("instance transform is null!");
        if(inventoryRect == null) Debug.LogWarning("inv rect null!"); */
        Instantiate(item.inventoryGameobject, inventoryRect);
        List<ItemSO> newItems = new();
        newItems.AddRange(items);
        newItems.Add(item);
        // Debug.Log("New items!: " + newItems.Count );
        items = newItems.ToArray();

    }

    public void RemoveItem(ItemSO item)
    {
        int searchIndex = System.Array.IndexOf(items, item);
        List<ItemSO> shortenedItems = new();
        for(int i = 0; i < items.Length; i++)
        {
            if(i == searchIndex) continue;
            shortenedItems.Add(items[i]);
        }

        items = shortenedItems.ToArray();
    }

    void PrintItemArray(ItemSO[] items)
    {
        if(items == null) 
        {
            Debug.LogWarning("Array is null! returning!");
            return;
        }

        for(int i = 0; i < items.Length; i++)
        {
            Debug.Log(items[i]);
        }
        Debug.Log("Ending print!");
    }

    void PopulateInventoryBar()
    {
        if(items == null) return;
        foreach(ItemSO item in items)
        {
            Instantiate(item.inventoryGameobject, inventoryRect);
        }
    }
}

