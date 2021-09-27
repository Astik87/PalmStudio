using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates2 : MonoBehaviour
{
    public knopka1 button1;
    public knopka2 button2;
    public knopka3 button3;
    public knopka4 button4;

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

        if (button1.state|| button2.state || button3.state || button4.state ) state = 1;
        else if (button1.state == false && button2.state == false && button3.state == false && button4.state == false) state = 0;



        if (state == 1 && transform.position.y != endPos.y)
            pos = 1;

        if (pos == 1) transform.position = Vector2.MoveTowards(transform.position, endPos, speed * Time.deltaTime);

        if (state == 1 && transform.position.y == endPos.y)
            pos = 2;

        if (pos == 2) transform.position = Vector2.MoveTowards(transform.position, startPos, speed * Time.deltaTime);


    }
}
