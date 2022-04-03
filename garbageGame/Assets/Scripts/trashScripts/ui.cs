using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ui : MonoBehaviour
{

	public GameObject baseMenuRef;
	public GameObject instructionsMenuRef;
	public GameObject helpMenuRef;
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
		helpMenuRef.SetActive(false);
		baseMenuRef.SetActive(false);
		instructionsMenuRef.SetActive(true);
	}

	public void back()
	{
		helpMenuRef.SetActive(false);
		instructionsMenuRef.SetActive(false);
		baseMenuRef.SetActive(true);
	}

	public void help()
	{
		instructionsMenuRef.SetActive(false);
		baseMenuRef.SetActive(false);
		helpMenuRef.SetActive(true);
	}

	public void home()
	{
		SceneManager.LoadScene("start scene");
	}
}
