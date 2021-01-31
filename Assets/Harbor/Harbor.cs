using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harbor : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Radio radioScript;
    public bool inHarbor;

    void OnTriggerEnter2D(Collider2D collision)
    {
        inHarbor = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        inHarbor = false;
    }
}
