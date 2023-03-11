using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextScene : MonoBehaviour
{
	public int nextSceneLoad;
	public GameObject EndUI;

	private float menuDelay = 6.0f;

	void Start()
	{
		nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
	}

	public void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			if(SceneManager.GetActiveScene().buildIndex == 6)
			{
				EndUI.SetActive(true);

				Invoke("ToMainMenu", menuDelay);
			}
			else
			{
			SceneManager.LoadScene(nextSceneLoad);
			
			if(nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
			{
				PlayerPrefs.SetInt("levelAt", nextSceneLoad);
			}
			}
		}
	}
	void ToMainMenu()
	{
		SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
	}
}
