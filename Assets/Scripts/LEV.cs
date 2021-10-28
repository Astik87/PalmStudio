using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class LEV : MonoBehaviour
{
    public bool state;
    public GameObject hatch;
    private GameObject Player;
    private Player PlayerCode;
    public GameObject Interact;
    public EventTrigger.Entry entry;

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

    public void interact()
    {


        state = true;
        if (!AudioLever.isPlaying) AudioLever.Play();
        else if (AudioLever.isPlaying) AudioLever.Stop();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (PlayerCode.interactObj == null)
            {
                Interact.GetComponent<EventTrigger>().triggers.Add(entry);
                Interact.SetActive(true);
                if (!AudioLever.isPlaying) AudioLever.Play();
            }
            else
            {
                AudioLever.Stop();
            }
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