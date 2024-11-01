using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameStarter : MonoBehaviour
{

    public GameObject startMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame()
    {
		//SceneManager.LoadScene("SampleScene");
        startMenu.SetActive(false);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
