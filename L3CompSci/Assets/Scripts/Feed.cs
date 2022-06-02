using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feed : MonoBehaviour
{

    public GameObject Story;
    public GameObject Story2;
    public GameObject Story3;

    public List<GameObject> sL = new List<GameObject>();

    void Start()
    {
        sL.Add(Story);
        sL.Add(Story2);
        sL.Add(Story3);

        sL[1].GetComponent<Animator>().SetBool("s1>2", true);
        sL[2].GetComponent<Animator>().SetBool("s1>2", true);
        sL[2].GetComponent<Animator>().SetBool("s2>3", true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Scroll();
        }
    }

    void Scroll()
    {
        sL[0].GetComponent<Animator>().SetBool("s1>2", true);
        sL[1].GetComponent<Animator>().SetBool("s2>3", true);
    }
}
