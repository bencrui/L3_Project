using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn : MonoBehaviour
{
    public TopicsManager m;
    private void OnMouseDown()
    {
        m.BtnClick();
    }
}