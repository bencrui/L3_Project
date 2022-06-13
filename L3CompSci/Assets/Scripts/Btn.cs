using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn : MonoBehaviour
{
    private void OnMouseDown()
    {
        GetComponentInParent<TopicsManager>().BtnClick();
    }
}