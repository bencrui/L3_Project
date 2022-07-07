using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feed : MonoBehaviour
{
    public DataGate dg;

    public List<string> storyStock = new List<string>(10);
    public Manager m;

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
        storyStock.Add("0S1234");

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
        Manager();
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
    }

    void Manager()
    {
        while (storyStock.Count >= 0)
        {
            char[] code = storyStock[0].ToCharArray(); // format: 0S1234
            foreach (char c in code)
            {
                Debug.Log(c);
            }
            if ((m.M +2) > code[2])
            {
                Debug.Log("GOING");
                Like(0, 0.5f);
            }
        }
        Debug.Log("Story Stock empty. You Lose.");
    }

    void Like(int likes, float sTime)
    {
        if (likes == 0)
        {
            foreach (SpriteRenderer r in sL[2].GetComponentsInChildren<SpriteRenderer>())
            {
                if (r.gameObject.name == "LikeBtn")
                {
                    r.color = new Color(0.70980392156f, 0.19607843137f, 0.14901960784f);
                    return;
                }
            }
        }
        Scroll(sTime);
    }

    IEnumerable Scroll(float sTime)
    {
        yield return new WaitForSeconds(sTime);
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
