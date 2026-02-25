using UnityEngine;

public class DestroyInventory : MonoBehaviour
{
    void Awake()
    {
        Destroy(Inventory.instance);
    }
}
