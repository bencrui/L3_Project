using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Topic : MonoBehaviour
{
    public string details;

    private void OnMouseDown()
    {
        GetComponentInParent<TopicsManager>().Click(this);
    }

}
