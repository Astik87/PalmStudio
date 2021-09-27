using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABOBA1 : MonoBehaviour
{
    private Rigidbody2D rb;

    private float progress;

    private Vector2 startPos;
    public Vector2 endPos;
    public Vector2 aboba;
    public int count;

   
    public int boxCount;
    public int state;
    public float speed;
    public int heroCount;
    public int a;

  
    public List<GameObject> GOinTrigger1 = new List<GameObject>();

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
        
       
       
        if (GOinTrigger1.Count >= heroCount * 1) a = 1;
        else a = 0;




        
        if ( a == 1 && transform.position.y != endPos.y)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GOinTrigger1.Add(collision.gameObject);
        }

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            GOinTrigger1.Remove(collision.gameObject);
        }

    }
}
