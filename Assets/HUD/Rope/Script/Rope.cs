using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    [SerializeField] AudioSource horn;
    [SerializeField] Animator animator;
    public void rope()
    {
        animator.SetTrigger("ropeTrigger");
        horn.PlayOneShot(horn.clip, 0.1f);
    }
}
