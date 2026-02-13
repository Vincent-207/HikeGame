using UnityEngine;

public class LevelAdder : MonoBehaviour
{
    [SerializeField] GameObject levelPrefab;
    [SerializeField] Vector2 spawnPos;
    public void AddLocation()
    {
        Debug.Log("Calling add");
        MapManager.instance.AddLocation(levelPrefab, spawnPos);
    }
}
