using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    [SerializeField] Transform inventoryRect;
    public GameObject[] items;
    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
            return;
        }

        instance = this;
        Debug.Log("Saving this thing!");
        DontDestroyOnLoad(this);
    }
    void OnLevelWasLoaded()
    {
        Start();
    }
    void Start()
    {
        Debug.LogWarning("Start is being ran!");
        inventoryRect = InventoryUI.instance.transform;
        
    }
    public void AddItem(GameObject item)
    {
        if(InventoryUI.instance == null) Debug.LogWarning("Inv rect instance is null!");
        else Debug.Log("inv rect instance is not null!");
        Debug.Log("inv rect name: " + InventoryUI.instance.gameObject.name);
        if(InventoryUI.instance.transform == null) Debug.LogWarning("instance transform is null!");
        if(inventoryRect == null) Debug.LogWarning("inv rect null!");
        Instantiate(item, inventoryRect);
        List<GameObject> newItems = new();
        newItems.AddRange(items);
        newItems.Add(item);
        items = newItems.ToArray();

    }
}

