using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] private Transform radarPing;
    [SerializeField] private LayerMask radarLayerMask;
    private Transform sweepTransform;
    public float rotationSpeed = 180f;
    private float radarDistance = 100f;
    private List<Collider2D> colliderList;

    // Start is called before the first frame update
    private void Awake()
    {
        sweepTransform = transform.Find("Sweep");
        colliderList = new List<Collider2D>();
    }

    static Vector3 GetVectorFromAngle(float angle) 
    {
        //angle 0 -> 360
        float angleRad = angle * (Mathf.PI/180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    // Update is called once per frame
    void Update()
    {
        float previousRotation = (sweepTransform.eulerAngles.z % 360) - 180;
        sweepTransform.eulerAngles -= new Vector3(0, 0, rotationSpeed * Time.deltaTime);
        float currentRotation = (sweepTransform.eulerAngles.z % 360) - 180;

        if ((previousRotation < 0) && (currentRotation >= 0))
        {
            colliderList.Clear();
        }

        RaycastHit2D[] raycastHit2DArray = Physics2D.RaycastAll(transform.position, GetVectorFromAngle(sweepTransform.eulerAngles.z), radarDistance, radarLayerMask);
        foreach (RaycastHit2D raycastHit2D in raycastHit2DArray)
        {
            if (raycastHit2D.collider != null)
            {
                //Hit something
                if (!colliderList.Contains(raycastHit2D.collider))
                {
                    //Hit something for the first time
                    colliderList.Add(raycastHit2D.collider);
                    audioSource.PlayOneShot(audioSource.clip, 0.04f);
                    Instantiate(radarPing, raycastHit2D.point, Quaternion.identity);
                }

            }
        }
    }
}
