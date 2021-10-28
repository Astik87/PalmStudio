using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StonePlatform12_2 : MonoBehaviour
{
    private Rigidbody2D rb;

    public Button button1;

    private float progress;

    private Vector2 startPos;
    public Vector2 endPos;

    public int state;
    public float speed;

    public List<GameObject> GOinTrigger = new List<GameObject>();

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

        if (button1.state)
        {
            state = 1;
        }
    }
}
