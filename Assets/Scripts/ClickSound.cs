using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour
{
   public void OnPointerClick()
    {
        GetComponent<AudioSource>().Play();
    }
}
