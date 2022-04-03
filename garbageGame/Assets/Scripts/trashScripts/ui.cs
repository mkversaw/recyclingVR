using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ui : MonoBehaviour
{
	public void startGame()
	{
		SceneManager.LoadScene("scene");
	}

	public void exitGame()
	{
		Application.Quit();
	}

	public void displaySettings()
	{

	}

	public void displayInstructions()
	{

	}
}
