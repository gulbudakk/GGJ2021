using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class TileIceScript : MonoBehaviour
{
    [Header("- - - References - - -")]

    [SerializeField] IceResist resistScript;
    private GameObject tilemapGameObj;
    private GameObject StateScriptObj;
    private GameState StateScript;

    private Tilemap tilemap;
    public GameObject[] objArr;
    [SerializeField] float slowtime;
 
    void Start()
    {
        StateScriptObj = GameObject.Find("Game State");
        StateScript = StateScriptObj.GetComponent<GameState>();
        tilemapGameObj = StateScript.tilemapGameObject;
        if (tilemapGameObj != null)
        {
            tilemap = tilemapGameObj.GetComponent<Tilemap>();
        }
    }


    //private void OnCollisionEnter2D(Collision2D other)
    //{

    //    Debug.Log("collide");
    //    Vector2 hitPosition = Vector2.zero;
    //    if (tilemap != null && tilemapGameObject == other.gameObject)
    //    {
    //        Debug.Log(tilemapGameObject);
    //        foreach (ContactPoint2D hit in other.contacts)
    //        {
    //            hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
    //            hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
    //            Debug.Log(hitPosition.x);
    //            tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);
    //        }
    //    }
    //}
    private void Update()
    {
        for (int i = 0; i < objArr.Length; i++)
        {
            if (tilemap != null && checkAllPivot())//ice var
            {
                StartCoroutine(slowShip(slowtime));
                tilemap.SetTile(tilemap.WorldToCell(objArr[i].transform.position), null);
            }
        }
    }

    public IEnumerator slowShip(float sec)
    {
        StateScript.ShipInIce = true;
        yield return new WaitForSeconds(sec);
        StateScript.ShipInIce = false;
    }
    bool checkAllPivot()
    {
        for (int i = 0; i < objArr.Length; i++)
        {
            if (tilemap.GetTile(tilemap.WorldToCell(objArr[i].transform.position)) != null)//eğer ice var ise
            {
                return true;
            }
        }
        return false;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        for (int i = 0; i < objArr.Length; i++)
        {
            if (tilemap != null && tilemapGameObj == other.gameObject && tilemap.GetTile(tilemap.WorldToCell(objArr[i].transform.position)) != null)
            {
                StateScript.ShipInIce = true;
                tilemap.SetTile(tilemap.WorldToCell(objArr[i].transform.position), null);
            }
        }
    }

    bool existArray(GameObject obj, GameObject[] arr)
    {
        for (int i = 0 ; i < arr.Length; i++)
        {
            if (arr[i] == obj)
            {
                return true;
            }
        }
        return false;
    }
    void DestroyTile()
    {
        Tilemap tilemap = GetComponentInParent<Tilemap>();
        Vector3Int pos = Vector3Int.FloorToInt(transform.position);
        tilemap.SetTile(pos, null);
    }

    IEnumerator DelayedDestroy()
    {
        //yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(1f);
        tilemap.SetTile(tilemap.WorldToCell(transform.position), null);
    }

    //void get_tile_pos_in_circle()
    //{
    //    float r = 1f;
    //    Vector2 radius_vec = new Vector2(r, r);
    //    Vector2 centro = new Vector2(0, 0);
    //    var min_pos = Math.Floor(centro - radius_vec);
    //    var max_pos = Math.ceiling(centro + radius_vec);

    //    var min_x = int(min_pos.x);
    //    var max_x = int(max_pos.x);
    //    var min_y = int(min_pos.y);
    //    var max_y = int(max_pos.y);

    //    var positions[];
    //}


    //func get_tile_positions_in_circle():
    //# Get the rectangle bounding the circle
    //var radius_vec = Vector2(_radius_in_tiles, _radius_in_tiles)
    //var min_pos = (_center_in_tiles - radius_vec).floor()
    //var max_pos = (_center_in_tiles + radius_vec).ceil()

    //# Convert to integer so we can use range for loop
    //var min_x = int(min_pos.x)
    //var max_x = int(max_pos.x)
    //var min_y = int(min_pos.y)
    //var max_y = int(max_pos.y)

    //var positions = []

    //# Gather all points that are within the radius
    //for y in range(min_y, max_y) :
    //    for x in range(min_x, max_x) :
    //        var tile_pos = Vector2(x, y)
    //        if tile_pos.distance_to(_center_in_tiles) < _radius_in_tiles:
    //             positions.append(tile_pos)

    //return positions

}
