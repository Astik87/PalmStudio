using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knopka5 : MonoBehaviour
{
    public bool state;
    private Vector2 startPos;
    public Vector2 endPos;
    internal bool interactable;
    void Start()
    {
        startPos = transform.position;
        endPos = new Vector2(startPos.x, startPos.y + 0.15f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y == endPos.y)
        {

            state = false;
        }
        if (state)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPos, Time.deltaTime);
        }
        else if (state == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, startPos, Time.deltaTime);
        }
    }
    public void setState(bool s)
    {
        state = s;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        setState(true);
    }
}
