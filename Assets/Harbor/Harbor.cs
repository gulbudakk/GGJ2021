using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harbor : MonoBehaviour
{
    [SerializeField] Rigidbody2D PlayerRB;
    [SerializeField] Radio radioScript;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (radioScript.isAttached)
        {
            Destroy(GameObject.FindGameObjectWithTag("Rescue"));
            radioScript.isMissonActive = false;
            radioScript.isAttached = false;
        }
        
    }
}
