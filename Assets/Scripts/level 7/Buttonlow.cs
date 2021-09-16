using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttonlow : MonoBehaviour
{
    // Start is called before the first frame update
   
    public int pos;
    public bool state;
    private Vector2 startPos;
    public Vector2 endPos;
    internal bool interactable;

    private void Start()
    {
        startPos = transform.position;
        endPos = new Vector2(startPos.x + 0.15f, startPos.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x == endPos.x)
        {
            pos = 0;
            state = false;
        }

        
            if (state)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPos, Time.deltaTime);
            pos = 1;
        }
        else if (state == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, startPos, Time.deltaTime);
        }


        if (state) pos = 1;
        if (state == false) pos = 0;

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
