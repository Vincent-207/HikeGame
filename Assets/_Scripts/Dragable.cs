
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Dragable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] InputActionReference mousePos;
    [SerializeField] GameObject returnButton, map, levelHolder;
    RectTransform rectTransform;
    Image image;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>(); 
        image = GetComponent<Image>();       
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        // Debug.Log("Begin");
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Debug.Log("Drag");
        Vector2 mouseScreenPos = mousePos.action.ReadValue<Vector2>();
        rectTransform.position = mouseScreenPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {   
        LevelPoint closestLevelPoint = getClosestLevelPoint();
        if(ValidDrop(closestLevelPoint))
        {
            map.SetActive(false);
            levelHolder.SetActive(true);
            GameObject level = Instantiate(closestLevelPoint.LevelPrefab, levelHolder.transform);
            level.transform.SetAsFirstSibling();
        }
        // Debug.Log("End");
    }

    LevelPoint getClosestLevelPoint()
    {
        List<LevelPoint> levelPoints = new();
        levelPoints.AddRange(map.transform.parent.GetComponentsInChildren<LevelPoint>());
        float minimumDistance = Mathf.Infinity;
        LevelPoint closestLevelPoint = null;
        foreach(LevelPoint levelPoint in levelPoints)
        {
            float distanceToLevelPoint = (levelPoint.transform.position - transform.position).magnitude;
            if(distanceToLevelPoint < minimumDistance)
            {
                minimumDistance = distanceToLevelPoint;
                closestLevelPoint = levelPoint;
            }
        }

        Debug.Log("Distance: " + minimumDistance);
        return closestLevelPoint;
    }


    bool ValidDrop(LevelPoint levelPoint)
    {
        float distance = (levelPoint.transform.position - transform.position).magnitude;
        if(distance < 100f) return true;
        return false;
    }
}