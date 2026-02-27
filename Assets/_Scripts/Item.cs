using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Item : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] InputActionReference mousePos;
    [SerializeField] ItemSO itemSO;
    [SerializeField] String useableText;
    GraphicRaycaster graphicRaycaster;
    bool isText;
    
    // public ItemType itemType;
    Image image;
    void Start()
    {
        graphicRaycaster = FindFirstObjectByType<GraphicRaycaster>();
        image = GetComponent<Image>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        transform.SetParent(transform.parent.parent);
        transform.SetAsLastSibling();
        Debug.Log("Begin drag!");
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = mousePos.action.ReadValue<Vector2>();
        MouseControl.instance.Grabbed();

        // update text
        List<RaycastResult> results = getRaycastOverMouse();
        foreach(RaycastResult raycastResult in results)
        {
            IItemConsumer itemConsumer = raycastResult.gameObject.GetComponent<IItemConsumer>();
            if(itemConsumer != null && itemConsumer.ItemMatches(itemSO.itemType))
            {
                // Item matches.
                CursorText.instance.SetText(useableText);
                
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        List<RaycastResult> results = getRaycastOverMouse();
        Debug.Log("End drag");
        foreach(RaycastResult raycastResult in results)
        {
            IItemConsumer itemConsumer = raycastResult.gameObject.GetComponent<IItemConsumer>();
            if(itemConsumer != null) Debug.Log("Item consumer: " + raycastResult.gameObject.name);
            if(itemConsumer != null && itemConsumer.ItemMatches(itemSO.itemType))
            {
                Debug.Log("Matches!");
                UseItem(itemConsumer);
                return;
            }
        }
                
        image.raycastTarget = true;
        transform.SetParent(transform.parent.GetChild(0));
        MouseControl.instance.Default();
    }

    void UseItem(IItemConsumer itemConsumer)
    {
        itemConsumer.AddItem(itemSO.itemType);
        Inventory.instance.RemoveItem(itemSO);
        Destroy(gameObject);    
    }

    List<RaycastResult> getRaycastOverMouse()
    {
        // If there are objects under
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = mousePos.action.ReadValue<Vector2>();
        List<RaycastResult> results = new();

        graphicRaycaster.Raycast(pointerEventData, results);
        return results;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        MouseControl.instance.Grabbable();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        MouseControl.instance.Default();

    }
}
[Serializable]
public enum ItemType
{
    None,
    RoadGateKey,
    medBottle,
    stick,
    chemicals,
    handle, 
    ladder,
    gun,
    tape,
    axe
}
