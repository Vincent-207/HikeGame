using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;
    [SerializeField] GameObject PointPrefab;
    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
            return;
        }

        instance = this;
        
    }

    public void AddLocation(GameObject levelPrefab, Vector2 mapPos)
    {
        Debug.Log("Map is adding");
        GameObject point = Instantiate(PointPrefab, Vector2.zero, Quaternion.identity, transform);
        point.GetComponent<LevelPoint>().LevelPrefab = levelPrefab;
        point.GetComponent<RectTransform>().anchoredPosition = mapPos;
    }
}
