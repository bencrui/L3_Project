using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feed : MonoBehaviour
{
    public DataGate dg;

    public List<string> storyStock = new List<string>(10);

    public GameObject Story;
    public GameObject Story2;
    public GameObject Story3;
    public GameObject StoryP;

    public List<GameObject> sL = new List<GameObject>();

    public RectTransform[] t;

    float h = Screen.height;
    float H = 0;
    int i = 0;

    void Start()
    {
        t = GetComponentsInChildren<RectTransform>();

        // The game will start at the 'loading' sequence of the social media, and so the player will input the first 3 or so stories, but for now....
        storyStock.Add("Title/Description/Comments");

        // set up all of the initial stories. Currently these are basic.
        sL.Add(Story);
        sL.Add(Story2);
        sL.Add(Story3);
        NewStory(true);
        // move initial stories to positions
        sL[1].GetComponent<Animator>().SetBool("s0>1", true);
        sL[2].GetComponent<Animator>().SetBool("s0>1", true);
        sL[3].GetComponent<Animator>().SetBool("s0>1", true);
        sL[2].GetComponent<Animator>().SetBool("s1>2", true);
        sL[3].GetComponent<Animator>().SetBool("s1>2", true);
        sL[3].GetComponent<Animator>().SetBool("s2>3", true);

    }

    void Update()
    {
        h = Screen.height;
        if (H != h)
        {
            for (int n = 10; n < t.Length; n += 2)
            {
                t[n].localScale = new Vector3(h / 10, h / 10, 1);
                t[n].position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 240 - (h/20), h - (h / 20) - (h * i) / 10, 100));
                i++;
            }
            i = 0;
            H = h;
        }
        
        //manual input for testing
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
        if (storyStock.Count == 0)
        {
            Debug.Log("Story Stock empty. You Lose.");
            return;
        }

        for (int i = 0; i < 4; i++) // animation
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

        for (int i = 0; i < storyStock.Count - 2; i++)
        {
            storyStock[i] = storyStock[1 + i];
        }
        storyStock.RemoveAt(storyStock.Count - 1);
    }

    void NewStory(bool starting)
    {
        int index = 0;

        if (starting)
        {
            index = sL.Count;
            sL.Add(Instantiate(StoryP, GetComponentInParent<Transform>()));
        }
        else  sL[0] = Instantiate(StoryP, GetComponentInParent<Transform>());

        sL[index].transform.localScale = new Vector3(60, 70, 0);
        sL[index].transform.position = new Vector3(6.4f, 12.25f, 0);
    }
}
