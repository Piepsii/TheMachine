using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFunctions : MonoBehaviour
{

    [SerializeField] Texture2D cursorTextureDefault;
    [SerializeField] Texture2D cursorTextureHolding;
    [SerializeField] Texture2D cursorTextureGrabbing;
    [SerializeField] Texture2D cursorTextureCrosshair;

    private string cursor;

    public void ToggleGameTime()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }
    public void ToggleGameTime(int scale)
    {
        Time.timeScale = scale;
    }

    public void ChangeCursor(string type)
    {
        if(type == "default")
        {
            Cursor.SetCursor(cursorTextureDefault, new Vector2(17, 9), CursorMode.Auto);
            cursor = "default";
        }
        else if(type == "holding")
        {
            Cursor.SetCursor(cursorTextureHolding, new Vector2(16, 16), CursorMode.Auto);
            cursor = "holding";
        }
        else if (type == "grabbing")
        {
            Cursor.SetCursor(cursorTextureGrabbing, new Vector2(16, 16), CursorMode.Auto);
            cursor = "grabbing";
        }
        else if (type == "crosshair")
        {
            Cursor.SetCursor(cursorTextureCrosshair, new Vector2(16, 16), CursorMode.Auto);
            cursor = "crosshair";
        }
        else
        {
            Cursor.SetCursor(cursorTextureDefault, new Vector2(2, 2), CursorMode.Auto);
            cursor = "default";
        }
    }

    public string CurrentCursor()
    {
        return cursor;
    }
}
