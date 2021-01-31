using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCollide : MonoBehaviour
{
    [Header("- - - References - - -")]

    private GameObject StateScriptObj;
    private GameState StateScript;
    private Knockback KnockbackScript;

    [Header("- - - Variables - - -")]

    [SerializeField] float KBduration;
    [SerializeField] float KBpower;

    private void Start()
    {
        StateScriptObj = GameObject.Find("Game State");
        StateScript = StateScriptObj.GetComponent<GameState>();

        KnockbackScript = StateScript.Ship.GetComponent<Knockback>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //StateScript.ShipInIce=true;
        //Debug.Log("collision!");
        //if (other.gameObject == StateScript.Ship)
        //{
        //    StartCoroutine(KnockbackScript.createKnockback(KBduration, KBpower, this.transform));
        //}
    }
}
