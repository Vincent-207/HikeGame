using Unity.VisualScripting;
using UnityEngine;

public class ScaryLadyHelper : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;
    public void GiveMedicine()
    {
        TextHoverable textHoverable = gameObject.AddComponent<TextHoverable>();
        textHoverable.hoverText = "Thank you for the medicine bottle.\nI feel so much better after vomiting out that handle.";
        GameObject newLady = Instantiate(prefab, transform.parent);
        newLady.transform.position = transform.position;
        newLady.transform.rotation = transform.rotation;
        newLady.transform.localScale = transform.localScale;
    }
}
