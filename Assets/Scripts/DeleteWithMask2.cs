using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteWithMask2 : MonoBehaviour
{
    [Header("- - - References - - -")]

    [SerializeField] GameObject Mask;
    [SerializeField] GameObject MaskPivot;

    [Header("- - - Variables - - -")]

    [SerializeField] float delay;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("Space"))
        {
            spawnMask();
        }
    }

    void spawnMask()
    {
        GameObject mask = Instantiate(Mask, MaskPivot.transform.position, MaskPivot.transform.rotation);
    }

   
}
