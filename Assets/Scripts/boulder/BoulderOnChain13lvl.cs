using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderOnChain13lvl : MonoBehaviour
{
    private Rigidbody2D rb;

    private float progress;

    private Vector2 startPos;
    private Vector2 endPos;
    public Vector2 Pos1;
    public Vector2 Pos2;
    public Vector3 Pos1_1;
    public Vector3 Pos2_1;
    public int state;
    public float speed1;
    public float speed2;

    // Start is called before the first frame updat
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = Pos1;
        endPos = Pos2;
        state = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == 1 && transform.rotation.z != Pos2_1.z)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(Pos2_1), speed2 * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, Pos2_1, speed1 * Time.deltaTime);
        }
        else if (state == 0 && transform.rotation.z != Pos1_1.z)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(Pos1_1), speed2 * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, Pos1_1, speed1 * Time.deltaTime);
        }

        if (state == 0 && transform.rotation.z == Pos1_1.z) state = 1;
        if (state == 1 && transform.rotation.z == Pos2_1.z) state = 0;


    }
}
