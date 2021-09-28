using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABOBA2 : MonoBehaviour
{
    private Rigidbody2D rb;
    public ABOBA1 aboba;
    private float progress;

    private Vector2 startPos;
    public Vector2 endPos;
    public int count;


    public int boxCount;
    public int state;
    public float speed;
    public int heroCount;
    public int a;


   

    //public AudioClip Chains;
    private AudioSource AudioChains;
    public GameObject soundObject;

    // Start is called before the first frame updat
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        count = 0;
        AudioChains = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (aboba.a == 1) a = 1;
        else a = 0;
        if (a == 1 && transform.position.y != endPos.y)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
            if (!AudioChains.isPlaying) AudioChains.Play();
        }
        else if (a == 0 && transform.position.y != startPos.y)
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
