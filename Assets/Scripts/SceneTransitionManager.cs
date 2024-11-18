using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject text;
    public float loadingScreenDuration = 3.0f;
    //public Animator fadeAnimator;//Optional if time
    public string nextScene;

    public void LoadNextScene()
    {
		StartCoroutine(LoadSceneCoroutine());

	}

	private IEnumerator LoadSceneCoroutine()
    {
        loadingScreen.SetActive(true); //Display screen

        yield return new WaitForSeconds(loadingScreenDuration);

        //if (fadeAnimator != null)//play fade animation
        //{
        //    fadeAnimator.SetTrigger("FadeOut");
        //    yield return new WaitForSeconds(1.0f);
        //}

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nextScene);
        asyncLoad.allowSceneActivation = false;

        //while (!asyncLoad.isDone)
        //{

        //    if(asyncLoad.progress >= 0.9f)
        //    {
        //        asyncLoad.allowSceneActivation = true;
        //    }

        //    yield return null; 
        //}

        while(asyncLoad.progress < 0.9f)
        {
            yield return null;
        }

        asyncLoad.allowSceneActivation = true;
    }
}
