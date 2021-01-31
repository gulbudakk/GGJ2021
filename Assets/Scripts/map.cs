using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] AudioSource audioSource;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && (canvas.activeSelf == false))
        {
            audioSource.PlayOneShot(audioSource.clip);
            canvas.SetActive(true);
        }

        else if (Input.GetKeyDown(KeyCode.M) && canvas.activeSelf)
        {
            audioSource.PlayOneShot(audioSource.clip);
            canvas.SetActive(false);
        }
    }
}
