using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFunctions : MonoBehaviour
{

    [SerializeField] Texture2D cursorTextureDefault;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorTextureDefault, new Vector2(17, 9), CursorMode.Auto);
    }
}
