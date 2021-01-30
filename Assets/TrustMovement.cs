using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrustMovement : MonoBehaviour
{

    public float limit = 0.5f;
    // Start is called before the first frame update
    bool isPicked;

    // Update is called once per frame
    float inital_x;
    float inital_y;
    void Start() 
    {
        inital_x = transform.position.x;
        inital_y = transform.position.y;
    }
        

    void Update()
    {
        //Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.position = (pos);

        if (Input.GetMouseButtonUp(0))
        {
            isPicked = false;
        }

        if (isPicked == true)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (mousePos.y > inital_y + limit)
            {
                mousePos = new Vector2(inital_x, inital_y + limit);
                transform.position = mousePos;
            }
            else if (mousePos.y < inital_y - limit+2)
            {
                mousePos = new Vector2(inital_x, inital_y - limit+2);
                transform.position = mousePos;
            }
            else
            {
                mousePos = new Vector2(inital_x, mousePos.y);
                transform.position = mousePos;
            }
        }
    }
    void OnMouseDown()
    {
        isPicked = true;
    }
}
