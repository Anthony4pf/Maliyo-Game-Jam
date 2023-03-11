using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetLevel : MonoBehaviour
{
	public Button[] ResetButtons;

	public void Reset()
	{
		PlayerPrefs.DeleteAll();

		int ResetAt = PlayerPrefs.GetInt("ResetAt", 2);

		for (int i = 0; i < ResetButtons.Length; i++)
		{
			if(i + 2 > ResetAt)
				ResetButtons[i].interactable = false;
		}
	}
}
