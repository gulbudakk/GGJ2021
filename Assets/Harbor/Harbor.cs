using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harbor : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int health;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (speed < 10)
        {
            health = 3;

        }
    }
}
