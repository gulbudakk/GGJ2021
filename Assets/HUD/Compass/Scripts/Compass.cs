using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    [SerializeField] Vector3 NorthDirection;
    [SerializeField] Transform player;
    
    [SerializeField] RectTransform northLayer;

    public void ChangeNorthDirection() 
    {
        NorthDirection.z = player.eulerAngles.z;
        northLayer.localEulerAngles = -NorthDirection;
    }
    void Update()
    {
        ChangeNorthDirection();
    }
}
