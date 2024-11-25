using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveOpeningTrigger : MonoBehaviour
{
    private SceneTransitionManager sceneTransitionManager;

    // Start is called before the first frame update
    void Start()
    {
        sceneTransitionManager = FindObjectOfType<SceneTransitionManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D other)
	{
        if (other.CompareTag("Player"))
        {
			Debug.Log("Player entered the cave trigger.");
			sceneTransitionManager.LoadNextScene();
		}

	}
		
}
