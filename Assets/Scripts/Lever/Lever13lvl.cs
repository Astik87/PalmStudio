using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Lever13lvl : MonoBehaviour
{
    private GameObject Player;
    public Platform thorns1;
    public Platform thorns2;
    public Platform thorns3;
    private Player PlayerCode;
    public GameObject Interact;
    public EventTrigger.Entry entry;
    public bool isActive;
    public float time;
    public float deltaY;
    public float y = 0;
    public Rigidbody2D rb;

    private AudioSource AudioLever;
    public GameObject soundObject;

    private void Awake()
    {
        Player = GameObject.Find("Player");
        PlayerCode = Player.GetComponent<Player>();
        Interact = GameObject.Find("Interact");
        AudioLever = GetComponent<AudioSource>();

        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) => {
            interact();
        });
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (isActive)
        {
            thorns1.boxCount = 0;
            thorns2.boxCount = 0;
            thorns3.boxCount = 0;
        }
    }

    public void interact()
    {
        isActive = true;
        if (!AudioLever.isPlaying) AudioLever.Play();
        else if (AudioLever.isPlaying) AudioLever.Stop();
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
