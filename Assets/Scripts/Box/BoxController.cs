using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class BoxController : MonoBehaviour
{

    private GameObject Player;
    Player PlayerCode;
    private DistanceJoint2D joint;
    public bool isInteract = false;
    private GameObject Interact;
    public EventTrigger.Entry entry;
    private void Awake()
    {
        Player = GameObject.Find("Player");
        PlayerCode = Player.GetComponent<Player>();
        Interact = GameObject.Find("Interact");

        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) => {
            if (isInteract) interactOut();
            else interact();
        });
    }

    public void interact()
    {
        if (Player.transform.position.x > transform.position.x && !PlayerCode.flip) PlayerCode.Flip();
        if (Player.transform.position.x < transform.position.x && PlayerCode.flip) PlayerCode.Flip();

        PlayerCode.flipAllowed = false;
        PlayerCode.jumpAllowed = false;
        joint = this.gameObject.AddComponent<DistanceJoint2D>();
        joint.autoConfigureDistance = true;
        joint.autoConfigureConnectedAnchor = false;
        joint.distance = 1;
        joint.enableCollision = true;
        joint.connectedAnchor = new Vector2(0f, -0.5f);
        joint.maxDistanceOnly = true;
        joint.breakForce = 75;
        joint.connectedBody = Player.GetComponent<Rigidbody2D>();
        PlayerCode.interactObj = this.gameObject;
        isInteract = true;
    }

    public void interactOut()
    {
        PlayerCode.flipAllowed = true;
        PlayerCode.jumpAllowed = true;
        PlayerCode.interactObj = null;
        Destroy(joint);
        isInteract = false;
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
            if (isInteract) interactOut();
            if (PlayerCode.interactObj == null)
            {
                Interact.SetActive(false);
                Interact.GetComponent<EventTrigger>().triggers.Remove(entry);
            }
        }
    }
}
