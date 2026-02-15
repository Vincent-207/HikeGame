using UnityEngine;
using UnityEngine.EventSystems;

public class ItemPickupable : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    GameObject itemToAdd;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Adding!");
        if(Inventory.instance == null) Debug.LogWarning("Inventory null!");
        Inventory.instance.AddItem(itemToAdd);
        Destroy(gameObject);
    }
}
