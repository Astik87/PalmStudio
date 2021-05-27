using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Lever : MonoBehaviour
{

    public GameObject obj;
    private GameObject Player;
    private Player PlayerCode;
    public GameObject Interact;
    public EventTrigger.Entry entry;
    public bool isActive;
    public float time;
    public float deltaY;
    public float y = 0;
    public Rigidbody2D rb;

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

    private void Start()
    {
        rb = obj.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isActive)
        {
            rb.AddForce(Vector2.up, ForceMode2D.Impulse);
        }
    }

    public void interact()
    {
        isActive = true;
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
