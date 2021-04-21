using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	public Rigidbody2D rb;
	public GameObject checkerGround;
	public float dx = 0f;
	public float speed = 2.5f;
	public float jumpForce = 5f;
	public bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dx = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dx*speed, 0);
        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) Jump();
    }

    void FixedUpdate() {
    	CheckGround();
    }

    void Jump() {
    	rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    void CheckGround() {
    	Collider2D[] collider = Physics2D.OverlapCircleAll(checkerGround.transform.position, 0.3f);
    	isGrounded = collider.Length > 1;
    }
}
