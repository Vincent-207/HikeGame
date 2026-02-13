using UnityEngine;
using UnityEngine.UI;
public class TimeImage : MonoBehaviour
{
    [SerializeField]
    Sprite[] icons;
    Image image; 
    void Start()
    {
        image = GetComponent<Image>();
    }
    public void SetIcon(DayTimeIcon dayTimeIcon)
    {
        image.sprite = icons[(int) dayTimeIcon];
    }
    public void SetIcon(int iconIndex)
    {
        image.sprite = icons[iconIndex];
    }
}

public enum DayTimeIcon
{
    sun,
    moon
}