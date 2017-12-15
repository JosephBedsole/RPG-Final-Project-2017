using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	public string scene;

	public Transform mainMenu;
	public Transform optionsMenu;


	public void PlayGame ()
	{
		SceneManager.LoadScene(scene);
	}

	public void OpenOptions ()
	{
		mainMenu.gameObject.SetActive(false);
		optionsMenu.gameObject.SetActive(true);
	}

	public void CloseOptions ()
	{
		mainMenu.gameObject.SetActive(true);
		optionsMenu.gameObject.SetActive(false);
	}

	public void QuitGame ()
	{
		Application.Quit();
	}
}
