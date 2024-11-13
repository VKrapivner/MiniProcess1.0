using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public GameObject loadingScreen;
    public Animator fadeAnimator;//Optional if time
    public string nextScene;

    public void LoadNextScene()
    {

    }

    private IEnumerator LoadSceneCoroutine()
    {
        loadingScreen.SetActive(true); //Display screen

        if(fadeAnimator != null)//play fade animation
        {
            fadeAnimator.SetTrigger("FadeOut");
            yield return new WaitForSeconds(1.0f);
        }

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nextScene);
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {

            if(asyncLoad.progress >= 0.9f)
            {
                asyncLoad.allowSceneActivation = true;
            }

            yield return null; 
        }
    }
}
