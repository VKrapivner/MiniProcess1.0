using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameStarter : MonoBehaviour
{

    public GameObject startMenu;
    public GameObject startGameButton;
    public GameObject resumeGameButton;
    public GameObject exitGameButton;

    public bool isGamePaused = false;

    // Start is called before the first frame update
    void Start()
    {
        startMenu.SetActive(true);
        startGameButton.SetActive(true);
        resumeGameButton.SetActive(false);
        exitGameButton.SetActive(false);
       
    }

    public void StartGame()
    {
        Debug.Log("Start Button pushed");
        startMenu.SetActive(false);
        Time.timeScale = 1.0f;
	}
	public void PauseGame()
	{
		Debug.Log("Game Paused");
		isGamePaused = true;
		Time.timeScale = 0.0f;
		startMenu.SetActive(true);
        startGameButton.SetActive(false);
        resumeGameButton.SetActive(true);
        exitGameButton.SetActive(true);
	}

	public void ResumeGame()
    {
		Debug.Log("Resume button pushed");
		startMenu.SetActive(false);
        isGamePaused = false;
		Time.timeScale = 1.0f;
	}

	public void ExitGame()
	{
		Debug.Log("Exit button pushed");

#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif

	}

	// Update is called once per frame
	void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if(isGamePaused)
                ResumeGame();
            else
                PauseGame();        
        }
    }
}
