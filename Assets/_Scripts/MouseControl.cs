
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    public Texture2D defaultCursor, clickableCursor, lockIconCursor, unlockedIconCursor, hoverableCursor, grabable, grabbed;
    public static MouseControl instance;

    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void Locked()
    {
        SetCursor(lockIconCursor);
    }

    public void Unlocked()
    {
        SetCursor(unlockedIconCursor);
    }
    public void Hoverable()
    {
        SetCursor(hoverableCursor);
    }

    public void Clickable()
    {
        SetCursor(clickableCursor);
    }

    public void Default()
    {
        SetCursor(defaultCursor);
        
    }

    public void Grabbable()
    {
        SetCursor(grabable);
    }

    public void Grabbed()
    {
        SetCursor(grabbed);
    }

    void SetCursor(Texture2D cursor)
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }
}
