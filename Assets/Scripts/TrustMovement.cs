using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class TrustMovement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float limit = 0.5f;
    public GameObject Reference;
    // Start is called before the first frame update
    bool isPicked;
    Vector2 pos;

    // Update is called once per frame
    float inital_x;
    float inital_y;
    Component comp;
    void Start()
    {
        comp = GetComponent<RectTransform>();
        pos = GetComponent<RectTransform>().anchoredPosition;
        inital_x = pos.x;
        inital_y = pos.y;
    }


    void Update()
    {
        //Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.position = (pos);

        //Vector2 mousePos = Input.mousePosition;
        //transform.position = mousePos;

        pos = GetComponent<RectTransform>().anchoredPosition;
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
                GetComponent<RectTransform>().anchoredPosition = mousePos;
                Reference.transform.position = mousePos;
            }
            else if (mousePos.y < inital_y)
            {
                mousePos = new Vector2(inital_x, inital_y);
                GetComponent<RectTransform>().anchoredPosition = mousePos;
                Reference.transform.position = mousePos;
            }
            else
            {
                mousePos = new Vector2(inital_x, mousePos.y);
                GetComponent<RectTransform>().anchoredPosition = mousePos;
                Reference.transform.position = mousePos;
            }
            //transform.position = mousePos;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPicked = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPicked = false;
    }
}