using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gates1 : MonoBehaviour
{
    public Buttonlow button;
    private Rigidbody2D rb;
    private Vector2 startPos;
    public Vector2 endPos;
    public int state;
    public float speed;
    public int pos = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (button.state) state = 1;
        else if (button.state == false) state = 0;



        if (state == 1 && transform.position.x != endPos.x)
            pos = 1;

        if (pos == 1) transform.position = Vector2.MoveTowards(transform.position, endPos, speed * Time.deltaTime);

        if (state == 1 && transform.position.x == endPos.x)
            pos = 2;

        if (pos == 2) transform.position = Vector2.MoveTowards(transform.position, startPos, speed * Time.deltaTime);

    }
}