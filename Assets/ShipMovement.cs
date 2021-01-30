using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public GameObject Wheel;
    public GameObject Trust;
    public int TurnSpeed=10;
    public float speed_s = 5f;
    Rigidbody2D rb;
    Vector2 to_add;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var localVelocity = transform.InverseTransformDirection(rb.velocity);
        var forwardSpeed = localVelocity.y;

        Debug.Log(forwardSpeed);

        if(forwardSpeed > Trust.transform.position.y)
        {
            to_add = new Vector2(-transform.up.x, -transform.up.y);
        }
        else if (forwardSpeed < Trust.transform.position.y)
        {
            to_add = new Vector2(transform.up.x, transform.up.y);
        }
        else
        {
            if(Trust.transform.position.y < 0) 
            {
                to_add = new Vector2(-transform.up.x, -transform.up.y);
            }
            else if (Trust.transform.position.y > 0)
            {
                to_add = new Vector2(transform.up.x, transform.up.y);
            }
        }


    }

    void RotateShip() 
    {
        this.transform.Rotate(Vector3.forward *  Wheel.transform.rotation.z * TurnSpeed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        rb.AddForce(to_add);
        RotateShip();
    }
}
