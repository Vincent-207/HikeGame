using UnityEngine;

public class ItemInteractable : MonoBehaviour
{
    GameObject itemScreenPrefab;
    public void Interact()
    {
        Instantiate(itemScreenPrefab, transform.parent);
    }
}
