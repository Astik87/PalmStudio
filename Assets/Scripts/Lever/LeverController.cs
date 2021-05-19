using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{

    public GameObject hatch;
    private GameObject Player;

    private void Start()
    {
        Player = GameObject.Find("Player");
    }

    public void interact()
    {
        Rigidbody2D rb = hatch.GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player.GetComponent<Player>().obj = this.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player.GetComponent<Player>().obj = null;
        }
    }
}
