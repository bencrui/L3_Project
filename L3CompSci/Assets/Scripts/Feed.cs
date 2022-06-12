using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feed : MonoBehaviour
{
    public GameObject Story;
    public GameObject Story2;
    public GameObject Story3;
    public GameObject StoryP;

    public List<GameObject> sL = new List<GameObject>();

    void Start()
    {
        sL.Add(Story);
        sL.Add(Story2);
        sL.Add(Story3);
        NewStory(true);

        sL[1].GetComponent<Animator>().SetBool("s0>1", true);
        sL[2].GetComponent<Animator>().SetBool("s0>1", true);
        sL[3].GetComponent<Animator>().SetBool("s0>1", true);
        sL[2].GetComponent<Animator>().SetBool("s1>2", true);
        sL[3].GetComponent<Animator>().SetBool("s1>2", true);
        sL[3].GetComponent<Animator>().SetBool("s2>3", true);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Scroll();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Like();
        }
    }

    void Like()
    {
        // 'like' the current main story
        foreach (SpriteRenderer r in sL[2].GetComponentsInChildren<SpriteRenderer>())
        {
            if (r.gameObject.name == "LikeBtn")
            {
                r.color = new Color(0.70980392156f, 0.19607843137f, 0.14901960784f);
                return;
            }
        }
    }

    void Scroll()
    {
        for (int i = 0; i < 4; i++)
        {
            sL[i].GetComponent<Animator>().SetBool("s"+(i)+">"+(i+1), true);
        }

        // need to change to when animation is finished:
        GameObject.Destroy(sL[3]);

        // move within array
        for (int i = 3; i > 0; i--)
        {
            sL[i] = sL[i - 1];
        }

        NewStory(false);
    }

    void NewStory(bool starting)
    {
        int index = 0;

        if (starting)
        {
            index = sL.Count;
            sL.Add(Instantiate(StoryP, GetComponentInParent<Transform>()));
        }
        else
        {
            index = 0;
            sL[0] = Instantiate(StoryP, GetComponentInParent<Transform>());
        }

        sL[index].transform.localScale = new Vector3(60, 70, 0);
        sL[index].transform.position = new Vector3(6.4f, 12.25f, 0);
    }
}
