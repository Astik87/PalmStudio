using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform11 : MonoBehaviour
{
    private Rigidbody2D rb;

    private float progress;

    private Vector2 startPos;
    public Vector2 endPos;
    public int state;
    public float speed;

    public List<GameObject> GOinTrigger = new List<GameObject>();

    //public AudioClip Chains;
    //private AudioSource AudioChains;
    //public GameObject soundObject;

    // Start is called before the first frame updat
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (state == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
        }
        else if (state == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
        }

    }

}
