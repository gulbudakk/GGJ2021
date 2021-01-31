using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    private GameObject Ship;

    private Rigidbody2D rb;
    void Start()
    {
        Ship = gameObject;
        rb = Ship.GetComponent<Rigidbody2D>();
    }

    public IEnumerator createKnockback(float KbDuration, float KbPower, Transform obj)
    {
        float timer = 0;

        while (KbDuration > timer)
        {
            timer += Time.deltaTime;
            Vector2 direction = (obj.transform.position - this.transform.position).normalized;
            rb.AddForce(-direction * KbPower);
        }
        yield return 0;
    }
}
