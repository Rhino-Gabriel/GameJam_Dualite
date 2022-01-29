using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setCursor : MonoBehaviour
{
    public Texture2D mouseCursor;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 cursorOffset = new Vector2(mouseCursor.width/2, mouseCursor.height/2);

        Cursor.SetCursor(mouseCursor, cursorOffset, CursorMode.Auto);
    }
}
