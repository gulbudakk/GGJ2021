using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceResist : MonoBehaviour
{
    [Header("- - - References - - -")]

    private GameObject StateScriptObj;
    private GameState StateScript;
    [SerializeField] Collider2D thisCollider;
    public Transform m_NewTransform;

    [Header("- - - Variables - - -")]

    [SerializeField] float cd;
    [SerializeField] float p;
    private float v;
    [SerializeField] Vector2 ship_point;

    [SerializeField] float forceAmount;
    private void Start()
    {
        StateScriptObj = GameObject.Find("Game State");
        StateScript = StateScriptObj.GetComponent<GameState>();

    }

    void FixedUpdate()
    {
        ship_point = m_NewTransform.position;
        if (thisCollider.bounds.Contains(ship_point))
        {
            StateScript.ShipInIce = true;
        }
        else
        {
            StateScript.ShipInIce = false;
        }

        if (StateScript.ShipInIce)
        {
            applyResist();
        }
    }

    void applyResist()
    {
        var rb = StateScript.Ship.GetComponent<Rigidbody2D>();
        v = rb.velocity.magnitude;

        var direction = -rb.velocity.normalized;
        forceAmount = (p * v * v * cd) / 2;
        rb.AddForce(direction * forceAmount);
    }
}
