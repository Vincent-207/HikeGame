using UnityEngine;
using UnityEngine.Assertions.Must;

public class LevelHelper : MonoBehaviour
{
    public void DestroyLevel()
    {
        Debug.Log(transform.parent.GetChild(0).name);
        Destroy(transform.parent.GetChild(0).gameObject);
    }
}
