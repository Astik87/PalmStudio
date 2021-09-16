using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform10level : MonoBehaviour
{
    private Rigidbody2D rb;

    private float progress;

    private Vector2 startPos;
    private Vector2 endPos;
    public Vector2 Pos1;
    public Vector2 Pos2;
    public Vector2 Pos3;
    public int count;
    public int boxCount;
    public int state;
    public float speed;

    public List<GameObject> GOinTrigger = new List<GameObject>();

    //public AudioClip Chains;
    private AudioSource AudioChains;
    public GameObject soundObject;

    // Start is called before the first frame updat
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        endPos = Pos2;
        count = 0;
        boxCount = 1;

        AudioChains = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        count = GOinTrigger.Count;
        if (GOinTrigger.Count >= boxCount * 2) state = 1;
        else state = 0;

        if (state == 1 && transform.position.y != endPos.y)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
            if (!AudioChains.isPlaying) AudioChains.Play();
        }
        else if (state == 0 && transform.position.y != startPos.y)
        {
            transform.position = Vector2.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
            if (!AudioChains.isPlaying) AudioChains.Play();
        }
        else
        {
            if (AudioChains.isPlaying) AudioChains.Stop();
        }

        if (transform.position.y == Pos2.y && startPos == Pos1)
        {
            boxCount = 2;
            startPos = Pos2;
        }
        if (transform.position.y == Pos2.y && GOinTrigger.Count >= boxCount * 2 && startPos == Pos2 && endPos == Pos2)
        {
            endPos = Pos3;
        }
        if (transform.position.y == Pos3.y)
        {
            startPos = Pos3;
            endPos = Pos2;
            state = 1;
            boxCount = 1;
        }
        if (transform.position.y == Pos2.y && startPos == Pos3 && GOinTrigger.Count >= boxCount * 2)
        {
            boxCount = 2;
            endPos = Pos1;
            startPos = Pos2;
        }
        //if (endPos == Pos1 && startPos == Pos2 && transform.position == Pos1) speed = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("box"))
        {
            GOinTrigger.Add(collision.gameObject);
        }
        else if (collision.CompareTag("Player"))
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
        else if (collision.CompareTag("Player"))
        {
            GOinTrigger.Remove(collision.gameObject);
        }
    }

}
