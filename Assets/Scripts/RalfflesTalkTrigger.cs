using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RalfflesTalkTrigger : MonoBehaviour
{
    public GameObject talkButton;
    public GameObject dialogBox;
    private bool isPlayerNearby = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        talkButton.SetActive(false);
        dialogBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E)) 
        {
            StartConversation();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player enters the trigger zone
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            talkButton.SetActive(true); // Show the talk button
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the player leaves the trigger zone
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            talkButton.SetActive(false); // Hide the talk button
        }
    }

    public void StartConversation()
    {
        talkButton.SetActive(false);
        dialogBox.SetActive(true);
    }
}