using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ui : MonoBehaviour
{

	public GameObject baseMenuRef;
	public GameObject instructionsMenuRef;
	public void startGame()
	{
		SceneManager.LoadScene("scene");
	}

	public void exitGame()
	{
		Application.Quit();
	}

	public void displayInstructions()
	{
		baseMenuRef.SetActive(false);
		instructionsMenuRef.SetActive(true);
	}

	public void back()
	{
		instructionsMenuRef.SetActive(false);
		baseMenuRef.SetActive(true);
	}
}
