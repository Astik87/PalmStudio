using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            print("Hi");
            FadeInOut.nextLevel = "Level2";
            FadeInOut.sceneEnd = true;
        }
    }
}
