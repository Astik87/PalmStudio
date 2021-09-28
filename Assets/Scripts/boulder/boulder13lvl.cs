using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boulder13lvl : MonoBehaviour
{
    private Rigidbody2D rb;

    public Button button1;
    public Button button2;

    private float progress;

    private Vector2 startPos;
    public Vector2 endPos;
    public Vector2 endPos2;
    public int state;
    public float speed;

    // Start is called before the first frame updat
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (state == 1 && transform.position.y != endPos.y)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
        }
        else if (state == 0 && transform.position.y != startPos.y)
        {
            transform.position = Vector2.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
        }
        if (button1.state) state = 1;

        if (button1.state && button2.state) endPos = endPos2;


    }
}
