using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform10LVL : MonoBehaviour
{
    private Rigidbody2D rb;

    private float progress;

    private Vector2 startPos;
    private Vector2 endPos;

    public Vector2 Pos1;
    public Vector2 Pos2;
    public Vector2 Pos3;
    public Vector2 Pos4;
    public Vector2 Pos5;
    public Vector2 Pos6;

    public int count;
    public int boxCount;
    public int state;
    public float speed;

    public List<GameObject> GOinTrigger = new List<GameObject>();

    // Start is called before the first frame updat
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = Pos1;
        endPos = Pos2;
        count = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
        count = GOinTrigger.Count;
        if (GOinTrigger.Count >= boxCount * 2) state = 1;
        //else state = 0;

        if (state == 1 && transform.position.y != endPos.y)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
        }
        else if (state == 0 && transform.position.y != startPos.y)
        {
            transform.position = Vector2.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
        }

        if (transform.position.x == Pos2.x && transform.position.y == Pos2.y)
        {
            endPos = Pos3;
        }
        else if (transform.position.x == Pos3.x && transform.position.y == Pos3.y)
        {
            endPos = Pos4;
        }
        else if (transform.position.x == Pos4.x && transform.position.y == Pos4.y)
        {
            endPos = Pos5;
        }
        else if (transform.position.x == Pos5.x && transform.position.y == Pos5.y)
        {
            endPos = Pos6;
        }
        else if (transform.position.x == Pos6.x && transform.position.y == Pos6.y)
        {
            speed = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GOinTrigger.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GOinTrigger.Remove(collision.gameObject);
        }
    }
}
