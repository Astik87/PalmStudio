using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pickup : MonoBehaviour
{
    public EventTrigger.Entry entry;
    public Inventory inventory;
    public GameObject Prefab;
    public string Name;
    public int count;
    public GameObject icon;
    private EventTrigger.Entry intEntry;

    private void Start()
    {
        inventory = GameObject.Find("Player").GetComponent<Player>().GetComponent<Inventory>();
        intEntry = new EventTrigger.Entry();
        intEntry.eventID = EventTriggerType.PointerDown;
        intEntry.callback.AddListener((data) => {
            if (inventory.add(Prefab, Name, count, entry)) transform.position = new Vector3(-1000, -1000, -1000);
        });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player.Interact.SetActive(true);
            Player.Interact.GetComponent<EventTrigger>().triggers.Add(intEntry);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player.Interact.SetActive(false);
            Player.Interact.GetComponent<EventTrigger>().triggers.Remove(intEntry);
        }
    }

}
