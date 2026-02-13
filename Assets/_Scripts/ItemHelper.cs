using UnityEngine;

public class ItemHelper : MonoBehaviour
{
    [SerializeField] GameObject ItemPanel;
    public void DestroyItem()
    {
        Destroy(ItemPanel);
    }
}
