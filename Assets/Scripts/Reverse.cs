using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reverse : MonoBehaviour
{
    [SerializeField] ShipMovement script;
    [SerializeField] Animator animator;
    private int count = 0;

    public void change()
    {
        if (script.reverse_button)
        {
            script.reverse_button = false;
            Debug.Log("Foward");
        }
        else
        {
            script.reverse_button = true;
            Debug.Log("Reverse");
        }
    }

    public void toActive()
    {
        if (count == 0)
        {
            animator.SetBool("activate", true);
            count++;
        }

        else
        {
            animator.SetBool("activate", false);
            count = 0;
        }
    }
}
