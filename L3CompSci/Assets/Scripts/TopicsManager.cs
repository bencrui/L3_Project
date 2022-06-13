using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopicsManager : MonoBehaviour
{
    public bool visible;
    Topic topicShown;
    public Animator anim;

    public void Click(Topic t)
    {
        if (visible && t == topicShown)
        {
            visible = false;
            anim.SetTrigger("UnClicked");
            Debug.Log("Hide Info");
        }
        else if (visible && t != topicShown)
        {
            //update details
            Debug.Log("Update Info");
        }
        else
        {
            visible = true;
            anim.SetTrigger("Clicked");
            Debug.Log("Show Info");
        }
        topicShown = t;
    }

    public void BtnClick()
    {
        topicShown.Buy();
    }
}
