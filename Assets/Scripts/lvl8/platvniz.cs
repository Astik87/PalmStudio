using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platvniz : MonoBehaviour
{
    public int state;
    public knopka button;
    public float speed;
    private Rigidbody2D rb;
    private Vector2 startPos;
    public Vector2 endPos;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (button.state) state =1;
        if(state ==1)
            transform.position = Vector2.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
    }
}
