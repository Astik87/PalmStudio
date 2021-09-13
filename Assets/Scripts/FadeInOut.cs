using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeInOut : MonoBehaviour {
	
	public static bool sceneEnd;
	public float fadeSpeed = 0.5f;
	private Image _image;
	private bool sceneStarting;

	void Awake ()
	{
		_image = GetComponent<Image>();
		_image.enabled = true;
		sceneStarting = true;
		sceneEnd = false;
	}

	void Update ()
	{
		if(sceneStarting) StartScene();
		if(sceneEnd) EndScene();
	}

	void StartScene ()
	{
		_image.color = Color.Lerp(_image.color, Color.clear, fadeSpeed * Time.deltaTime);

		if(_image.color.a <= 0.01f)
		{
			_image.color = Color.clear;
			_image.enabled = false;
			sceneStarting = false;
		}
	}

	void EndScene ()
	{
		UnlockLevel();
		_image.enabled = true;
		_image.color = Color.Lerp(_image.color, Color.black, fadeSpeed * Time.deltaTime);

		if(_image.color.a >= 0.95f)
		{
			_image.color = Color.black;
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}

	public void UnlockLevel()
	{
		int currentLevel = SceneManager.GetActiveScene().buildIndex;

		if (currentLevel >= PlayerPrefs.GetInt("levels"))
		{
			PlayerPrefs.SetInt("levels", currentLevel + 1);
		}
	}

}