using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HIGH : MonoBehaviour
{
    public LOW button1;
    public int irr = 0;
    public bool state3;
    private Vector2 startPos;
    public Vector2 endPos;
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        endPos = new Vector2(startPos.x, startPos.y+0.15f);
    }

    // Update is called once per frame
    public void Update()
    {
        if (transform.position.y == endPos.y)
        {
            state3 = false;
            irr++;
        }


        if (state3)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, endPos, Time.deltaTime);
        }
        else if (state3 == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, startPos, Time.deltaTime);
        }

    }
    public void setState(bool s)
    {
        state3 = s;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        setState(true);
    }

}
