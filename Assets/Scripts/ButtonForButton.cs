using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonForButton : MonoBehaviour
{
    public bool state;

    public Rigidbody2D box;

    private Vector2 startPos;
    public Vector2 endPos;
    internal bool interactable;

    private void Start()
    {
        startPos = transform.position;
        endPos = new Vector2(startPos.x + 0.15f, startPos.y);
    }

    private void Update()
    {
        if (state)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPos, Time.deltaTime);
        }
        else
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
