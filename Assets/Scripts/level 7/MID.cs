using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MID : MonoBehaviour
{
    public int arr;
    public LOW button1;
    public bool state2;
    private Vector2 startPos;
    public Vector2 endPos;
    void Start()
    {
        startPos = transform.position;
        endPos = new Vector2(startPos.x - 0.15f, startPos.y);
    }

    // Update is called once per frame
    public void Update()
    {
        if (transform.position.x == endPos.x)
        {
            state2 = false;
            arr++;
        }


        if (state2)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPos, Time.deltaTime);
        }
        else if (state2 == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, startPos, Time.deltaTime);
        }

    }
    public void setState(bool s)
    {
        state2 = s;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        setState(true);
    }
}
