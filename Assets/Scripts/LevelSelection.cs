using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
	public Button[] LevelButtons;
	public GameObject[] levelLocks;

    void Start()
    {
		int levelAt = PlayerPrefs.GetInt("levelAt", 2);

		for (int i = 0; i < LevelButtons.Length; i++)
		{
			if(i + 2 > levelAt)
				LevelButtons[i].interactable = false;
		}		
    }

	void Update()
	{
		LockLevelUI();
	}
	public void LockLevelUI()
	{
		for (int i = 0; i < levelLocks.Length; i++)
		{
			if(LevelButtons[i].interactable == false)
			{
				levelLocks[i].SetActive(true);
			}
			else
			{
				levelLocks[i].SetActive(false);
			}
		}
	}
	/*
	public void OnLockUIOne()
	{
		if(LevelButtons[1].interactable == false)
		{
			LockUIOne.SetActive(true);
		}
		else
		{
			LockUIOne.SetActive(false);
		}
	}
	public void OnLockUITwo()
	{
		if(LevelButtons[2].interactable == false)
		{
			LockUITwo.SetActive(true);
		}
		else
		{
			LockUITwo.SetActive(false);
		}
	}
	*/	
}
