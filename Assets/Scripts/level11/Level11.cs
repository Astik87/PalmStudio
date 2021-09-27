using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Level11 : MonoBehaviour
{
    public PlatformHorizontal platform;
    public Platform11 platform2;
    public Button btn;
    public Button btn2;
    public Rigidbody2D stone;

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

    void Update() {
        stone.simulated = btn.state;
        if (btn2.state) platform2.state = 1;
    }

    public void interact()
    {
        platform.speed = 1f;
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
