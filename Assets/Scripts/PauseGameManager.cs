using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameManager : MonoBehaviour
{
	private bool isPaused = false;
	[SerializeField] private GameObject menuCanvas;

	private void Start()
	{
		Debug.Log("PauseGameManager is active!");
		
		if(menuCanvas != null)
			menuCanvas.SetActive(false);
		else
			Debug.LogError("MenuCanvas is not assigned in the Inspector!");

	}

	void Update()
	{
		Debug.Log("Entered Update function in PauseGameManager");
		if (Input.GetKeyDown(KeyCode.O))
		{
			Debug.Log("O Key is pressed");

			if (isPaused)
				ResumeGame();
			else
				PauseGame();
		}
	}

	public void PauseGame() 
	{
		Debug.Log("PauseGame called!");
		Time.timeScale = 0;
		menuCanvas.SetActive(true);
		isPaused = true;
	}

	public void ResumeGame() 
	{
		Debug.Log("ResumeGame called!");
		Time.timeScale = 1;
		menuCanvas.SetActive(false);
		isPaused = false;
	}

	public void ExitGame() 
	{
		Debug.Log("Exiting game...");
		Application.Quit();
	}
}

