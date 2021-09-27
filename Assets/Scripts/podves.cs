using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class podves : MonoBehaviour
{
    private Rigidbody2D rb;

    private float progress;

    private Vector2 startPos;
    public Vector2 endPos;
    public Vector2 endPos1;
    public Vector2 aboba;
    public int count;

    public LUK luk;
    public int boxCount;
    public int state;
    public float speed;
    public int heroCount;
    public int a;

    public List<GameObject> GOinTrigger = new List<GameObject>();
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

        aboba = endPos1;
        AudioChains = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (luk.state == 0)
            endPos1 = endPos;
        else
            endPos1 = aboba;
        count = GOinTrigger.Count;
        if (GOinTrigger.Count >= boxCount * 2) state = 1;
        else state = 0;
        if (GOinTrigger1.Count >= heroCount * 1) a = 1;
        else a = 0;




        if (state == 0&&a==1 && transform.position.y != endPos.y)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
            if (!AudioChains.isPlaying) AudioChains.Play();
        }
        else if (state == 1 && a == 1 && transform.position.y != endPos1.y)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPos1, speed * Time.deltaTime);
            if (!AudioChains.isPlaying) AudioChains.Play();
        }
        
        else if (state == 1 && a == 0 && transform.position.y != endPos1.y)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
            if (!AudioChains.isPlaying) AudioChains.Play();
        }
        else if(state == 0 && a == 0 && transform.position.y != startPos.y)
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

        if (collision.CompareTag("box"))
        {
            GOinTrigger.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("box"))
        {
            GOinTrigger.Remove(collision.gameObject);
        }
        if (collision.CompareTag("Player"))
        {
            GOinTrigger1.Remove(collision.gameObject);
        }

    }

}
