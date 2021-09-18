

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl7 : MonoBehaviour
{

    public gates1 gates;
    public int pos;
    private Rigidbody2D rb;

    private float progress;

    private Vector2 startPos;
    private Vector2 startPos1;
    public Vector2 endPos;

    public int state;
    public float speed;
    public int count;

    public Vector2 sh;

    //public AudioClip Chains;
    private AudioSource AudioChains;
    public GameObject soundObject;

    // Start is called before the first frame updat
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        sh = startPos;
        startPos1.x = 3.5F;
        startPos1.y = 1.76F;

         AudioChains = GetComponent<AudioSource>();
    }
   
    // Update is called once per frame
    void Update()
    {
      
      
        if (transform.position.y == startPos.y) pos = 0;
       else if (transform.position.y == endPos.y) pos = 1;

        if (gates.pos == 1)
        {
            startPos = startPos1;
        }
        else
        {
            startPos = sh;
        }

        if (pos == 0)
        {

            transform.position = Vector2.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
            if (!AudioChains.isPlaying) AudioChains.Play();
        }
        else if (pos==1)
        {
            transform.position = Vector2.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
            if (!AudioChains.isPlaying) AudioChains.Play();
        }
        else
        {
            if (AudioChains.isPlaying) AudioChains.Stop();
        }



    }

}
