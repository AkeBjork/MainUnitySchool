using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public void SetVisible(bool visible)
    {
        Cursor.visible = visible;
    }
}
