using UnityEngine;

public class PlayerPrefsClear : MonoBehaviour
{
    
    void Start()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }

}
