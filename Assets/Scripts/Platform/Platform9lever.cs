using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform9lever : MonoBehaviour
{
    private Rigidbody2D rb;

    private float progress;

    private Vector2 startPos;
    public Vector2 endPos;
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
        count = 0;

        AudioChains = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        //count = GOinTrigger.Count;
        //if (GOinTrigger.Count >= boxCount * 2) state = 1;
        //else state = 0;

        if (state == 1 && transform.position.x != endPos.x)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
            if (!AudioChains.isPlaying) AudioChains.Play();
        }
        else if (state == 0 && transform.position.x != startPos.x)
        {
            transform.position = Vector2.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
            if (!AudioChains.isPlaying) AudioChains.Play();
        }
        else
        {
            if (AudioChains.isPlaying) AudioChains.Stop();
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("box"))
    //    {
    //        GOinTrigger.Add(collision.gameObject);
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("box"))
    //    {
    //        GOinTrigger.Remove(collision.gameObject);
    //    }
    //}

}