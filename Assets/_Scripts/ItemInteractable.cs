using UnityEngine;

public class ItemInteractable : MonoBehaviour
{
    [SerializeField] GameObject itemScreenPrefab;
    public void Interact()
    {
        Instantiate(itemScreenPrefab, transform.parent);
    }
}
