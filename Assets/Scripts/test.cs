using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class test : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
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

        //Vector2 mousePos = Input.mousePosition;
        //transform.position = mousePos;

        if (Input.GetMouseButtonUp(0))
        {
            isPicked = false;
        }

        if (isPicked == true)
        {
            //Debug.Log
            Vector2 mousePos = Input.mousePosition;

            

            if (mousePos.y > inital_y + limit)
            {
                mousePos = new Vector2(inital_x, inital_y + limit);
                transform.position = mousePos;
            }
            else if (mousePos.y < inital_y)
            {
                mousePos = new Vector2(inital_x, inital_y);
                transform.position = mousePos;
            }
            else
            {
                mousePos = new Vector2(inital_x, mousePos.y);
                transform.position = mousePos;
            }
            //transform.position = mousePos;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Pointer Test: Point Down");
        isPicked = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Pointer Test: Point Up");
        isPicked = false;
    }
}
