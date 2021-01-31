using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public GameObject Wheel;
    public GameObject Trust;
    public int TurnSpeed=10;
    float x;
    public GameObject ForcePos;
    public float reverse = 1f;
    public float foward = 1f;
    public GameObject Reference;
    public float degree;
    float inital_y;
    public bool reverse_button = false;
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

        x = Reference.transform.position.y - 30;
        //Debug.Log(x);
        //Debug.Log(reverse_button);

        float maxspeed = x / 30;
        if (!reverse_button) 
        { 
            maxspeed = x / 30;
            if (forwardSpeed < maxspeed)
            {
                to_add = new Vector2(transform.up.x * foward, transform.up.y * foward);//get faster
            }
            //else if (forwardSpeed > maxspeed)
            //{
            //    to_add = new Vector2(-transform.up.x * reverse, -transform.up.y * reverse);//slow down
            //}
            else
            {
                to_add = new Vector2(0, 0);
            }
        }
        else
        {
            Debug.Log("xd");
            maxspeed = -x / 60;
            if (forwardSpeed > maxspeed)
            {
                to_add = new Vector2(0.5f *-transform.up.x * reverse, 0.5f * -transform.up.y * reverse);//get faster
                Debug.Log("xd");
            }
            //else if (forwardSpeed > maxspeed)
            //{
            //    to_add = new Vector2(0.5f * transform.up.x * foward, 0.5f * transform.up.y * foward);//slow down
            //}
            else
            {
                to_add = new Vector2(0, 0);
            }
        }

        //if (!reverse_button)
        //{
        //    if (forwardSpeed > x)//slow down
        //    {
        //        to_add = new Vector2(-transform.up.x * reverse, -transform.up.y * reverse);
        //    }
        //    else if (forwardSpeed < x)//get faster
        //    {
        //        to_add = new Vector2(transform.up.x * foward, transform.up.y * foward);
        //    }
        //    else
        //    {
        //        if (x > 0)//get faster
        //        {
        //            to_add = new Vector2(transform.up.x * foward, transform.up.y * foward);
        //        }
        //    }
        //}
        //else
        //{
        //    if (x < 0) //slow down
        //    {
        //        to_add = new Vector2(-transform.up.x * reverse, -transform.up.y * reverse);
        //    }
        //}
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

        var localVelocity = transform.InverseTransformDirection(rb.velocity);
        float forwardSpeed = localVelocity.y;
        if (forwardSpeed < 0.15 && x==0 && forwardSpeed > -0.15)
        {
            rb.velocity = new Vector2(0, 0);
        }
        else
        {
            Vector2 stabilizer = new Vector2(0.5f * -rb.velocity.x, 0.5f * -rb.velocity.y);
            rb.AddForce(stabilizer);
        }
        
    }

    void FixedUpdate()
    {
        rb.AddForce(to_add);
        /*transform.position.x, transform.position.y-1,*/
        //rb.AddForceAtPosition(to_add, new Vector2(ForcePos.transform.position.x, ForcePos.transform.position.x));
        RotateShip();
        Stabilize();
    }
}
