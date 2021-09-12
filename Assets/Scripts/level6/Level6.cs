using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level6 : MonoBehaviour
{
    public Button button1;
    public Button button2;

    private Rigidbody2D rb;

    private float progress;

    private Vector2 startPos;
    public Vector2 endPos;
    public Vector2 endPos1;
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

        AudioChains = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
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
        if (button1.state) state = 1;
        if (button2.state) endPos = endPos1;
    }

}
