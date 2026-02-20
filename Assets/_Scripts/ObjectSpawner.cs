
using Unity.VisualScripting;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] bool isPrefab;
    [SerializeField] GameObject prefab;
    [SerializeField] Vector3 position, rotation, scale;
    public void Spawn()
    {
        if(isPrefab)
        {
            Transform transform = Instantiate(prefab).transform;
            if(!position.Equals(Vector3.zero)) transform.position = position;
            if(!rotation.Equals(Vector3.zero)) transform.rotation = Quaternion.Euler(rotation);
            if(!scale.Equals(Vector3.zero)) transform.localScale = scale;
            
        }
        else
        {
            prefab.SetActive(true);
        }
    }
}
