using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StonePlatform13LVL : MonoBehaviour
{
    private Rigidbody2D rb;

    private int i;

    public Button button1;

    private float progress;

    private Vector2 startPos;
    public Vector2 endPos;
    public Vector2 endPos2;
    public Vector2 endPos3;
    public int count;
    public int boxCount;
    public int state;
    public float speed;

    public List<GameObject> GOinTrigger = new List<GameObject>();

    // Start is called before the first frame updat
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        count = 0;
        i = 0;

    }

    // Update is called once per frame
    void Update()
    {

        count = GOinTrigger.Count;
        if (GOinTrigger.Count >= boxCount * 2 && i == 1) state = 1;
        else if (GOinTrigger.Count >= boxCount * 2 && i == 2) state = 0;

        if (state == 1 && transform.position.y != endPos.y)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
        }
        else if (state == 0 && transform.position.y != startPos.y)
        {
            transform.position = Vector2.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
        }

        if (button1.state && i == 0)
        {
            boxCount = 0;
            i = 1;
        }

        if (transform.position.y == endPos.y)
        {
            boxCount = 1;
            startPos = endPos2;
            i = 2;
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
