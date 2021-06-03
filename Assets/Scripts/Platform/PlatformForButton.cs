using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformForButton : MonoBehaviour
{

    private Rigidbody2D rb;

    private float progress;

    private Vector2 startPos;
    public Vector2 endPos;
    public int state;
    public float speed;

    public Button[] buttons;

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

        bool f = false;

        for (int i = 1; i < buttons.Length; i++)
        {
            if (!buttons[i - 1].state && buttons[i].state) f = true;
        }

        if (f)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].setState(false);
            };
        }

        if (buttons[buttons.Length - 1].state)
        {
            state = 1;
        } else
        {
            state = 0;
        }


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
    }

}
