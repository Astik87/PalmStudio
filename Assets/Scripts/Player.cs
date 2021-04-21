using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
	public GameObject checkerGround;
    public Joystick joystick;
	private float dx = 0f;
    private float dy = 0f;
	public float speed = 2.5f;
	public float jumpForce = 15f;
	public bool isGrounded = false;
    public float jumpTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        dx = joystick.Horizontal;
        dy = joystick.Vertical;
        sprite.flipX = dx < 0f;
        if (!isGrounded) {
            speed = 1.25f;
            jumpTime = 0f;
        } 
        else { 
            speed = 2.5f;
            jumpTime += Time.deltaTime;
        }
        rb.velocity = new Vector2(dx*speed, 0);
        if (isGrounded && dy >= 0.5f && jumpTime >= 0.5f) {
            rb.velocity = Vector2.up * jumpForce;
        }
        anim.SetBool("isJump", !isGrounded);
        anim.SetFloat("speed", Mathf.Abs(dx));
    }

    void FixedUpdate() {
    	CheckGround();
    }

    void CheckGround() {
    	Collider2D[] collider = Physics2D.OverlapCircleAll(checkerGround.transform.position, 0.25f);
    	isGrounded = collider.Length > 1;
    }

}
