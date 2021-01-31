using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskLoader : MonoBehaviour
{
    [Header("- - - References - - -")]

    private GameObject StateScriptObj;
    private GameState StateScript;

    private Transform maskPos;
    private Transform shipPos;
    [SerializeField] float maxRange;

    [SerializeField] GameObject maskReplacementObj;
    private SpriteRenderer maskReplacement;

    private void Awake()
    {
        StateScriptObj = GameObject.Find("Game State");
        StateScript = StateScriptObj.GetComponent<GameState>();

        maskPos = gameObject.transform;
        shipPos = StateScript.Ship.transform;

        //maskReplacement = maskReplacementObj.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Distance(maskPos, shipPos) > maxRange)
        {
            GameObject maskReplace = Instantiate(maskReplacementObj, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
        //else if (Distance(maskPos, shipPos) <= maxRange && gameObject.activeSelf == false)
        //{
        //    //maskReplacementObj.SetActive(true);
        //}
    }

    private float Distance(Transform item, Transform player)
    {
        return Vector3.Distance(item.position, player.position);
    }
}
