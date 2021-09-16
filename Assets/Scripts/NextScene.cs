using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex < SceneManager.sceneCount - 1)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }

        print(SceneManager.GetActiveScene().buildIndex);
    }
}
