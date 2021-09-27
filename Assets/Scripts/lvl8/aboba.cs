using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aboba : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 startPos;
    public Vector2 endPos;
    public int state;
    public float speed;
    public int pos;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if ( transform.position.y == startPos.y)
            pos = 1;

        if(pos==1) transform.position = Vector2.MoveTowards(transform.position, endPos, speed * Time.deltaTime);

        if (transform.position.y == endPos.y)
            pos = 2;

        if(pos==2) transform.position = Vector2.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
    }
}
