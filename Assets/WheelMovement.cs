using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WheelMovement : MonoBehaviour
{
    public int rotateSpeed = 25;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d"))
        {
            Rotate(-1);
        }
        if (Input.GetKey("a"))
        {
            Rotate(+1);
        }


    }

    void Rotate(int x) 
    {
        transform.Rotate(Vector3.forward * x * rotateSpeed * Time.deltaTime);
    }
        

}
