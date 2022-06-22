using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TopicsManager : MonoBehaviour
{
    public DataGate dg;

    public string[] TopicData;
    Topic[] Topics = new Topic[30]; //change to array when topics are finished

    public bool visible;
    Topic topicShown;

    public Sprite[] topicType;
    public GameObject detailsTab;
    Vector3 mpi;
    Vector3 gpi;

    public bool startedDragging = false;

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
            //hide details
            visible = false;
            detailsTab.GetComponent<Animator>().SetTrigger("UnClicked");
        }
        else if (visible && t != topicShown)
        {
            //update details
            Alter(dg.SkillDetails(t.ID));
        }
        else
        {
            //show details
            Alter(dg.SkillDetails(t.ID));
            visible = true;
            detailsTab.GetComponent<Animator>().SetTrigger("Clicked");
        }
        topicShown = t;
    }

    public void BtnClick()
    {
        topicShown.Buy(dg.Codes(topicShown.ID));
    }

    public void Dragging()
    {
        if (!startedDragging)
        {
            gpi = transform.position;
            mpi = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        transform.position = gpi + Camera.main.ScreenToWorldPoint(Input.mousePosition) - mpi;
    }

    private void Alter(string[] details)
    {
        TextMeshPro[] t = detailsTab.GetComponentsInChildren<TextMeshPro>();
        Debug.Log(t[0].text);
        t[0].text = details[0];
        t[1].text = details[1];
    }
}
