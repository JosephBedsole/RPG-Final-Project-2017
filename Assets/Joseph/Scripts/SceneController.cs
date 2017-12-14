using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
	
	public static SceneController instance;

	void Awake ()
	{
		if (instance == null)
		{
			instance = this;
		}
	}

	public string sceneGlobal;
	

	public void ChangeScene()
	{
		SceneManager.LoadScene(sceneGlobal);
	}

	public void QuitGame()
	{
		Application.Quit();
	}


}
