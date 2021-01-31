using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    [SerializeField] Animator animator;
    public void rope()
    {
        animator.SetTrigger("ropeTrigger");

    }
}
