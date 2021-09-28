using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOW : MonoBehaviour
{
    public HIGH button3;
    public MID button2;

    public int chet;
    public int a=0;
    public bool state1;
    private Vector2 startPos;
    public Vector2 endPos;
    void Start()
    {
        startPos = transform.position;
        endPos = new Vector2(startPos.x - 0.15f, startPos.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x == endPos.x)
        {
            state1 = false;
            a++;
        }


        if (state1)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, endPos, Time.deltaTime);
        }
        else if (state1 == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, startPos, Time.deltaTime);
        }



        

        if (button3.irr == 1 && button2.arr == 0 && a == 0)//первое нажатие
        {
            chet = 1;
            
        }
        

        if (chet == 1)//второе нажатие
        {
            
            
                if (button3.irr == 1 && button2.arr == 0 && a == 1)
                
                    chet = 2;
                  
        }
        

        if (chet == 2)//третье нажатие
        {
            
                if (button3.irr == 2 && button2.arr == 0 && a == 1)
                    chet = 3;
  
                
        }
        

        if (chet == 3)
        {//четвертое нажатие
            
                if (button3.irr == 2 && button2.arr == 1 && a == 1)
                    chet = 4;
                
        }
        
        if (chet == 4)//пятое нажатие
        {


            if (button3.irr == 2 && button2.arr == 1 && a == 2)
                chet = 5;

        }
        
    }
    public void setState(bool s)
    {
        state1 = s;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        setState(true);
    }
}
