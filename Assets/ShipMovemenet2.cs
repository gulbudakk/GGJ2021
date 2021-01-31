using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovemenet2 : MonoBehaviour
{
    public GameObject Wheel;
    public GameObject Trust;
    public int TurnSpeed = 10;

    public GameObject ForcePos;
    public float reverse = 1f;
    public float foward = 1f;
    public GameObject Reference;
    public bool reverse_button = false;
    Rigidbody2D rb;
    Vector2 to_add;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {

    }
}
