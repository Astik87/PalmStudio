using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 2.5f;
    public float jumpForce = 5f;
    public float groundRadius = 0.2f;
    public float dx;
    public bool flip = false;
    public bool flipAllowed = true;
    public bool jumpAllowed = true;
    public bool moveAllowed = true;
    Collider2D[] colliders;
    public Inventory inventory;

    public GameObject checkerGround;
    public Joystick joystick;
    public static Rigidbody2D rb;
    public Animator anim;

    public GameObject interactObj;
    public static GameObject Interact;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player.Interact = GameObject.Find("Interact");
        Player.Interact.SetActive(false);
        inventory = GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        colliders = Physics2D.OverlapCircleAll(checkerGround.transform.position, groundRadius);
        dx = joystick.Horizontal;
        if (moveAllowed) rb.velocity = new Vector2(dx * speed, rb.velocity.y);
        if (flip == false && dx < 0) Flip();
        else if (flip == true && dx > 0) Flip();
        if (moveAllowed) anim.SetFloat("speed", Mathf.Abs(dx));
        anim.SetBool("isJump", colliders.Length <= 1);
    }

    public void Flip()
    {
        if (!flipAllowed) return;
        flip = !flip;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    public void Jump()
    {
        if (colliders.Length > 1 && jumpAllowed)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

}
