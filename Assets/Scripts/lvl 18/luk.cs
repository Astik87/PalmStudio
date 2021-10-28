using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class luk : MonoBehaviour
{
    public LEVER lever;
    public LEVE lever1;
    public LEV lever2;
    private Rigidbody2D rb;
    private Vector2 startPos;
    public Vector2 endPos;
    public int state;
    public float speed;
    public Vector2 nachalo;
    public Vector2 end1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        nachalo = transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        if (lever.state) state = 1;
        if (state == 1) transform.position = Vector2.MoveTowards(transform.position, endPos, speed * Time.deltaTime);

        if (lever1.state) state = 1;
        {
            if (nachalo == endPos) 
            transform.position = Vector2.MoveTowards(transform.position, end1, speed * Time.deltaTime);
        }


    }
}