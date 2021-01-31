using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WheelMovement : MonoBehaviour
{
    public int rotateSpeed = 25;
    Vector3 newRotationAngles;
    int angle=0;
    bool flag = true;
    void Start() 
    {
        newRotationAngles = transform.rotation.eulerAngles;
    }
    // Update is called once per frame
    void Update()
    {
        
            flag = true;
            //Debug.Log(angle);
            if (Input.GetKey("d") && angle > -358.9)
            {
                newRotationAngles.z += -1;
                angle += -1; flag = false;
        }
            else if (Input.GetKey("a") && angle < 358.9)
            {
            //Debug.Log("a");
                newRotationAngles.z += 1;
                angle += 1; flag = false;
        }
            
         


    }

    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(newRotationAngles);
        if (angle < 6 && angle > -6 && flag)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            angle = 0;
        }
    }
        

}
