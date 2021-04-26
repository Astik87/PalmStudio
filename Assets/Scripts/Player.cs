using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float groundRadius;
    private float dx;
    private float dy;
    private bool flip = false;

    public GameObject checkerGround;
    public Joystick joystick;
    private Rigidbody2D rb;
    public Animator anim;


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
        if (colliders.Length > 1 && dy >= 0.5f)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        anim.SetBool("isJump", colliders.Length <= 1);
        anim.SetFloat("speed", dx);
    }

    void Flip()
    {
        flip = !flip;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

}
