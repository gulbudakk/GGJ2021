using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Radio : MonoBehaviour
{
    [SerializeField] bool isMissonActive;
    [SerializeField] GameObject ship;
    [SerializeField] private Text textBox;

    Vector2 spawnShip() 
    {
        int x = Random.Range(-2000, 2000);
        int y = Random.Range(-2000, 2000);
        Vector2 spawnLocation = new Vector2(x, y);
        Instantiate(ship, spawnLocation, Quaternion.identity);
        return spawnLocation;
    }

    public void sendRopes() 
    {
        if (true)
        {
            textBox.text = "Connecting the ship, captain!";
        }

        else
        {
            textBox.text = "You need to get close to the ship.";
        }
        Invoke("clearText", 5);

    }

    public void getMisson() 
    {
        if (isMissonActive)
        {
            textBox.text = ("You already have an active mission");
            Invoke("clearText", 5);
        }

        else
        {
            Vector2 spawnLocation = spawnShip();
            textBox.text = ("There is a ship to be rescued at x = " + spawnLocation.x + " y = " + spawnLocation.y + ".");
            isMissonActive = true;
            Invoke("clearText", 5);
        }
    }

    private void clearText()
    {
        textBox.text = "";
    }
}
