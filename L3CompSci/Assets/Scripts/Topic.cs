using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Topic : MonoBehaviour
{
    public Feed f;
    public string details;
    public List<Topic> unlockingTopics = new List<Topic>();
    public bool Unlocked = false;
    public bool Locking = true;
    public int Bought;
    public int Multiplier;
    public int Price;

    private void OnMouseDown()
    {
        GetComponentInParent<TopicsManager>().Click(this);
    }

    public void Buy()
    {
        if (Unlocked)
        {
            Debug.Log("Buying Now!");
            Bought++;
            if (Locking)
            {
                Locking = false;
                foreach (Topic e in unlockingTopics)
                {
                    e.Unlocked = true;
                }
                Debug.Log("Unlocking!");
            }
        }
        else
            Debug.Log("Not Yet!");
    }

}
