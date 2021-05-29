using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Lever2 : MonoBehaviour
{
    
    public Platform platform;

    private GameObject Player;
    private Player PlayerCode;
    public GameObject Interact;
    public EventTrigger.Entry entry;

    private void Awake()
    {
        Player = GameObject.Find("Player");
        PlayerCode = Player.GetComponent<Player>();
        Interact = GameObject.Find("Interact");

        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) => {
            interact();
        });
    }

    public void interact()
    {
    	platform.boxCount = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (PlayerCode.interactObj == null) Interact.GetComponent<EventTrigger>().triggers.Add(entry);
            Interact.SetActive(true);
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (PlayerCode.interactObj == null)
            {
                Interact.SetActive(false);
                Interact.GetComponent<EventTrigger>().triggers.Remove(entry);
            }
        }
    }
    
}
