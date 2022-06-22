using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chat : MonoBehaviour
{
    public Animator anim;

    string Name;

    Chat(string name)
    {
        this.Name = name;
    }

    private void OnMouseEnter()
    {
        anim.SetBool("In", false);
    }

    private void OnMouseExit()
    {
        anim.SetBool("In", true);
    }

    private void OnMouseDown()
    {
        
    }
}
