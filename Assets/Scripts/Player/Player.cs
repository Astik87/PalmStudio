using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 2.5f;
    public float jumpForce = 5f;
    public float groundRadius = 0.2f;
    public float dx;
    private float dy;
    public bool flip = false;
    public bool flipAllowed = true;
    public bool jumpAllowed = true;

    public GameObject checkerGround;
    public GameObject Interact;
    public Joystick joystick;
    public static Rigidbody2D rb;
    public Animator anim;

    public GameObject obj = null;
    public GameObject interactObj;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dx = joystick.Horizontal;
        dy = joystick.Vertical;
        rb.velocity = new Vector2(dx * speed, rb.velocity.y);
        if (flip == false && dx < 0) Flip();
        else if (flip == true && dx > 0) Flip();
        Collider2D[] colliders = Physics2D.OverlapCircleAll(checkerGround.transform.position, groundRadius);
        if (colliders.Length > 1 && dy >= 0.5f && jumpAllowed)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        anim.SetBool("isJump", colliders.Length <= 1);
        anim.SetFloat("speed", Mathf.Abs(dx));
    }

    public void Flip()
    {
        if (!flipAllowed) return;
        flip = !flip;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    public void GoToInteract()
    {
        if (obj != null || interactObj != null)
        {
            if (obj.CompareTag("lever"))
            {
                obj.GetComponent<LeverController>().interact();
            } else

            if (obj.CompareTag("box") || interactObj.CompareTag("box"))
            {
                if (interactObj != null) interactObj.GetComponent<BoxController>().interactOut();
                else if (obj != null) obj.GetComponent<BoxController>().interact();
            }
        }


    }

}
