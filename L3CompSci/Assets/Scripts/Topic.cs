using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Topic : MonoBehaviour
{
    bool dataShown = false;

    void Start()
    {
        foreach (SpriteRenderer s in GetComponentsInChildren<SpriteRenderer>())
        {
            s.enabled = false;
            dataShown = false;
        }
        this.GetComponent<SpriteRenderer>().enabled = true;
        GetComponentInChildren<MeshRenderer>().enabled = false;
    }
    private void OnMouseDown()
    {
        if (dataShown)
        {
            foreach (SpriteRenderer s in GetComponentsInChildren<SpriteRenderer>())
            {
                s.enabled = false;
                dataShown = false;
            }
            this.GetComponent<SpriteRenderer>().enabled = true;
            GetComponentInChildren<MeshRenderer>().enabled = false;
        }
        else 
        {
            foreach (SpriteRenderer s in GetComponentsInChildren<SpriteRenderer>())
            {
                s.enabled = true;
                dataShown = true;
            }
            GetComponentInChildren<MeshRenderer>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
