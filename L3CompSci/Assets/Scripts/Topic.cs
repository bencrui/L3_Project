using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Topic : MonoBehaviour
{
    public Feed f;
    public List<Topic> unlockingTopics = new List<Topic>();
    public bool Unlocked = false;
    public bool Locking = true;
    public int Bought;
    public int Multiplier;
    public int Price;
    public int ID;

    public char[] Details;

    private void OnMouseDown()
    {
        GetComponentInParent<TopicsManager>().Click(this);
    }

    public void Buy(string details)
    {
        if (Unlocked)
        {
            if (f.storyStock.Count <= 10)
            {
                Bought += 1;
                Debug.Log("Bought!");
                f.storyStock.Add(details);

                if (Locking)
                {
                    Locking = false;
                    foreach (Topic t in unlockingTopics)
                    {
                        t.Unlocked = true;
                        t.GetComponent<SpriteRenderer>().sprite = GetComponentInParent<TopicsManager>().topicType[0];
                    }
                    Debug.Log("Unlocking!");
                }
            }
            else
            {
                Debug.Log("STOCK IS FULL");
            }
        }
        else
            Debug.Log("Not Yet!");
    }

}
