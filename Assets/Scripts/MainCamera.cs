using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{

	Camera m_MainCamera;

    // Start is called before the first frame update
    void Start()
    {
    	m_MainCamera = Camera.main;
        m_MainCamera.aspect = 16f / 9f;
    }
}
