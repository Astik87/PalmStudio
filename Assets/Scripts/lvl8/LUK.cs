using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LUK : MonoBehaviour
{
    public LEVER lever;
    private Rigidbody2D rb;
    private Vector2 startPos;
    public Vector2 endPos;
    public int state;
    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (lever.state) state = 1;
        if (state == 1) transform.position = Vector2.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
    }
}
