using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopicsManager : MonoBehaviour
{
    public DataGate dg;

    public string[] TopicData;
    Topic[] Topics = new Topic[30]; //change to array when topics are finished

    public bool visible;
    Topic topicShown;

    public GameObject detailsTab;

    void Start()
    {
        int index = 0;
        foreach (Topic t in GetComponentsInChildren<Topic>())
        {
            Topics[index] = t;
            t.ID = index;
            index++;
        }
    }

    public void Click(Topic t)
    {
        if (visible && t == topicShown)
        {
            visible = false;
            detailsTab.GetComponent<Animator>().SetTrigger("UnClicked");
            Debug.Log("Hide Info");
        }
        else if (visible && t != topicShown)
        {
            //update details
            Alter(dg.SkillDetails(t.ID));
        }
        else
        {
            visible = true;
            detailsTab.GetComponent<Animator>().SetTrigger("Clicked");
            Debug.Log("Show Info");
        }
        topicShown = t;
    }

    public void BtnClick()
    {
        topicShown.Buy(dg.Codes(topicShown.ID));
    }

    private void Alter(string[] details)
    {
        TextMesh[] t = detailsTab.GetComponentsInChildren<TextMesh>();
        t[1].text = details[0];
        t[2].text = details[1];
    }
}
