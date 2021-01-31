using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class TileIceScript : MonoBehaviour
{
    [Header("- - - References - - -")]

    public GameObject tilemapGameObject;

    private GameObject StateScriptObj;
    private GameState StateScript;

    private Tilemap tilemap;
    private Transform startTransform;

    void Start()
    {
        StateScriptObj = GameObject.Find("Game State");
        StateScript = StateScriptObj.GetComponent<GameState>();

        if (tilemapGameObject != null)
        {
            tilemap = tilemapGameObject.GetComponent<Tilemap>();
            Debug.Log("tilemap assigned");
        }
        startTransform = gameObject.transform;
    }


    private void OnCollisionEnter2D(Collision2D other)
    {

        Debug.Log("collide");
        Vector2 hitPosition = Vector2.zero;
        if (tilemap != null && tilemapGameObject == other.gameObject)
        {
            Debug.Log(tilemapGameObject);
            foreach (ContactPoint2D hit in other.contacts)
            {
                hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
                hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
                Debug.Log(hitPosition.x);
                tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);
            }
        }
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    gameObject.transform.position = startTransform.position;
    //    gameObject.transform.rotation = startTransform.rotation;

    //    Debug.Log("collide");
    //    Vector2 hitPosition = Vector2.zero;
    //    if (tilemap != null && tilemapGameObject == other.gameObject)
    //    {
    //        Debug.Log(tilemapGameObject);
    //        foreach (ContactPoint2D hit in other.GetContacts)
    //        {
    //            hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
    //            hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
    //            Debug.Log(hitPosition.x);
    //            tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);
    //        }
    //    }
    //}

}
