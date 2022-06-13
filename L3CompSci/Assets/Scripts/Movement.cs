using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public TopicsManager m;
    private void OnMouseDrag()
    {
        m.Dragging();
        m.startedDragging = true;
    }
    private void OnMouseUp()
    {
        m.startedDragging = false;
    }
}
