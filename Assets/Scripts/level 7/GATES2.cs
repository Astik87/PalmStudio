using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GATES2 : MonoBehaviour
{
    public LOW button;
    private Rigidbody2D rb;
    private Vector2 startPos;
    public Vector2 endPos;
    public int state;
    public float speed;
    public int pos = 0;
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (button.chet==5 )
            transform.position = Vector2.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
    }
}
