using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour
{
    private void Start()
    {
        Texture2D crosshair = Resources.Load<Texture2D>("Sprites/Crosshair");
        Cursor.SetCursor(crosshair, Vector2.zero, CursorMode.Auto);
    }
}
