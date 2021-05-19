using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BoxController : MonoBehaviour
{

    private GameObject Player;
    private DistanceJoint2D joint;
    public bool isInteract = false;

    private void Start()
    {
        Player = GameObject.Find("Player");
    }

    public void interact()
    {
        Player PlayerCode = Player.GetComponent<Player>();

        if (Player.transform.position.x > transform.position.x && !PlayerCode.flip) PlayerCode.Flip();
        if (Player.transform.position.x < transform.position.x && PlayerCode.flip) PlayerCode.Flip();

        PlayerCode.flipAllowed = false;
        PlayerCode.jumpAllowed = false;
        joint = this.gameObject.AddComponent<DistanceJoint2D>();
        joint.autoConfigureDistance = false;
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
        Player PlayerCode = Player.GetComponent<Player>();

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
            Player.GetComponent<Player>().obj = this.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player.GetComponent<Player>().obj = null;
            interactOut();
        }
    }
}
