using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoading : MonoBehaviour
{
    
    public SceneName sceneName;
    public Image progressBar;
    void Start()
    {
        StartCoroutine(LoadAsyncOperation());
    }

    IEnumerator LoadAsyncOperation(){
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync("Prison");
        while(gameLevel.progress < 1){
            progressBar.fillAmount = gameLevel.progress;
            yield return new WaitForEndOfFrame();
        }
        LevelSelector.setCurrentScene();
    }
}
