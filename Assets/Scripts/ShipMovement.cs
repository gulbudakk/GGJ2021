using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public GameObject Wheel;
    public GameObject Trust;
    public int TurnSpeed=10;

    public float reverse = 1f;
    public float foward = 1f;

    public float degree;
    Rigidbody2D rb;
    Vector2 to_add;
    [SerializeField] float sidewaysDragmMltiplier; //how fast do you want your object to slow down
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
        if(forwardSpeed > Trust.transform.position.y)//slow down
        {
            to_add = new Vector2(-transform.up.x * reverse, -transform.up.y * reverse);
        }
        else if (forwardSpeed < Trust.transform.position.y)//get faster
        {
            to_add = new Vector2(transform.up.x * foward, transform.up.y * foward);
        }
        else
        {
            if(Trust.transform.position.y < 0) //slow down
            {
                to_add = new Vector2(-transform.up.x * reverse, -transform.up.y * reverse);
            }
            else if (Trust.transform.position.y > 0)//get faster
            {
                to_add = new Vector2(transform.up.x * foward, transform.up.y * foward);
            }
        }
    }

    void RotateShip() 
    {
        var localVelocity = transform.InverseTransformDirection(rb.velocity);
        float forwardSpeed = localVelocity.y;
        float turnSpeedAcoringTOSpeed;
        if (forwardSpeed == 0)
        {
            turnSpeedAcoringTOSpeed = 0f;
        }
        else if (Trust.transform.position.y == 0)
        {
            turnSpeedAcoringTOSpeed = 0f;
        }
        else
        {
            turnSpeedAcoringTOSpeed = (forwardSpeed - 0f) / (3 - 0) * (0.1f - 1f) + 1f;
        }

    
        float rotationSide = Wheel.transform.rotation.z;
        if (rotationSide < 0)//rotation - side
        {
            if (Wheel.transform.rotation.eulerAngles.z < 180)
            {
                degree = -2 + -rotationSide;
            }
            else
            {
                degree = rotationSide;
            }
        }
        else if(rotationSide > 0)//rotation + side
        {
            if (Wheel.transform.rotation.eulerAngles.z < 180)
            {
                degree = rotationSide;
            }
            else
            {
                degree = 2 + -rotationSide;
            }
        }       

        this.transform.Rotate(Vector3.forward * degree * TurnSpeed * Time.deltaTime * turnSpeedAcoringTOSpeed);
    }

    void Stabilize()
    {
        //Vector3 velocity = transform.InverseTransformDirection(rb.velocity);
        //rb.AddForce(transform.right * -velocity.x * sidewaysDragmMltiplier);

        Vector2 stabilizer = new Vector2(0.5f*-rb.velocity.x, 0.5f*-rb.velocity.y);
        rb.AddForce(stabilizer);
    }

    void FixedUpdate()
    {
        //rb.AddForce(to_add);
        rb.AddForceAtPosition(to_add, new Vector2(transform.position.x, transform.position.y));
        RotateShip();
        Stabilize();

        foreach (Transform oChild in transform)
        {
            if (oChild.name == "gamı")
            {
                oChild.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;
            }
        }
    }
}
