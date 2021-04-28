using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BoxController : MonoBehaviour
{

    private GameObject Player;
    public Transform posLeft;
    public Transform posRight;
    private bool isInteract = false;

    private void Start()
    {
        Player = GameObject.Find("Player");
    }

    public void interact()
    {
        if (!isInteract)
        {
            float distanceLeft = Vector2.Distance(posLeft.position, Player.transform.position);
            float distanceRight = Vector2.Distance(posRight.position, Player.transform.position);

            if (distanceLeft < distanceRight)
            {
                if (Player.GetComponent<Player>().flip) Player.GetComponent<Player>().Flip();
                Player.transform.position = posLeft.position;
            }
            else
            {
                if (!Player.GetComponent<Player>().flip) Player.GetComponent<Player>().Flip();
                Player.transform.position = posRight.position;
            }

            Player.GetComponent<Player>().flipAllowed = false;
            Player.GetComponent<Player>().jumpAllowed = false;
            this.gameObject.transform.parent = Player.transform;
            isInteract = true;
            Player.GetComponent<Player>().interactObj = this.gameObject;
        } else
        {
            Player.GetComponent<Player>().flipAllowed = true;
            Player.GetComponent<Player>().jumpAllowed = true;
            this.gameObject.transform.parent = null;
            isInteract = false;
            Player.GetComponent<Player>().interactObj = null;
        }
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
