using UnityEngine;
[RequireComponent(typeof(RectTransform))]
public class InventoryUI : MonoBehaviour
{
    public static InventoryUI instance;

    void Awake()
    {
        // Debug.Log("inv rect start!");
        if(instance != null && instance != this)
        {
            // Debug.Log("Destroying inv rect!");
            Destroy(this);
            return;
        }
        // Debug.Log("Inv rect is this!");
        instance = this;
    }
}
