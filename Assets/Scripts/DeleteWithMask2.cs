using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteWithMask2 : MonoBehaviour
{
    [Header("- - - References - - -")]

    [SerializeField] GameObject Mask;
    [SerializeField] GameObject MaskPivot;

    [Header("- - - Variables - - -")]

    private float delayStart;
    [SerializeField] float maskCD;

    // Start is called before the first frame update
    void Start()
    {
        delayStart = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if ( Time.time > delayStart + maskCD)
        {
            delayStart = Time.time;
            spawnMask();
        }
    }

    void spawnMask()
    {
        GameObject mask = Instantiate(Mask, MaskPivot.transform.position, MaskPivot.transform.rotation);
    }

   
}
