using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Radio : MonoBehaviour
{
    [SerializeField] private GameObject indicator;
    [SerializeField] private AudioClip[] radioSounds;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject[] spawnPoints;

    [SerializeField] private AudioClip ropeSound;

    public bool isMissonActive;
    [SerializeField] GameObject shipToSpawn;
    [SerializeField] private Text textBox;

    [SerializeField] GameObject Player;
    private GameObject rescueShip;
    private CircleCollider2D triggerCircle;
    private AttachScript attachScript;
    public bool isAttached = false;

    [SerializeField] private Harbor harborSctript;

    AudioClip RandomClip()
    {
        return radioSounds[Random.Range(0, radioSounds.Length)];
    }

    private Vector2 spawnShip() 
    {
        int x = Random.Range(-0, spawnPoints.Length-1);
        Vector2 spawnLocation = spawnPoints[x].transform.position;
        Instantiate(shipToSpawn, spawnLocation, Quaternion.identity);
        Instantiate(indicator, spawnLocation, Quaternion.identity);
        rescueShip = GameObject.FindGameObjectWithTag("Rescue");
        attachScript = rescueShip.GetComponentInChildren<AttachScript>();
        triggerCircle = rescueShip.GetComponentInChildren<CircleCollider2D>();

        return spawnLocation;
    }

    IEnumerator ShowText(string text)
    {
        string currentText = "";
        for (int i = 0; i <= text.Length; i++)
        {
            currentText = text.Substring(0, i);
            textBox.text = currentText;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void sendRopes() 
    {
        if (attachScript.isTriggered)
        {
            audioSource.PlayOneShot(RandomClip());
            StartCoroutine(ShowText("Connecting the ship, captain!"));
            audioSource.PlayOneShot(ropeSound, 0.8f);
            rescueShip.GetComponent<WheelJoint2D>().enabled = true;
            rescueShip.GetComponent<WheelJoint2D>().connectedBody = Player.GetComponent<Rigidbody2D>();
            rescueShip.layer = 9;
            BoxCollider2D[] colliders = Player.GetComponents<BoxCollider2D>();
            foreach (BoxCollider2D collider in colliders)
            {
                collider.enabled = true;
            }

            isAttached = true;
        }

        else if (isAttached)
        {
            if (harborSctript.inHarbor)
            {
                audioSource.PlayOneShot(RandomClip());
                StartCoroutine(ShowText("Thank you for your service!"));
                Destroy(GameObject.FindGameObjectWithTag("Rescue"));
                isMissonActive = false;
                isAttached = false;
            }

            else
            {
                audioSource.PlayOneShot(RandomClip());
                StartCoroutine(ShowText("We have already connected, captain!"));
            }
        }

        else
        {
            audioSource.PlayOneShot(RandomClip());
            StartCoroutine(ShowText("You need to get close to the ship."));
        }
        Invoke("clearText", 5);

    }

    public void getMisson() 
    {
        if (isMissonActive)
        {
            audioSource.PlayOneShot(RandomClip());
            StartCoroutine(ShowText("You already have an active mission."));
            Invoke("clearText", 5);
        }

        else
        {
            Vector2 spawnLocation = spawnShip();
            audioSource.PlayOneShot(RandomClip());
            StartCoroutine(ShowText("There is a ship to be rescued at x = " + spawnLocation.x + " y = " + spawnLocation.y + "."));
            Invoke("clearText", 5);
            isMissonActive = true;
        }
    }

    private void clearText()
    {
        textBox.text = "";
    }
}
