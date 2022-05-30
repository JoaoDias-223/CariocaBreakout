using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

public class LevelSelector : MonoBehaviour
{
    private static Scene scene;
    private SoundControl _soundControl;

    private void Awake() {
        setCurrentScene();
    }

    private void Start()
    {
        _soundControl = Object.FindObjectOfType<SoundControl>();
        if(_soundControl == null){
            Debug.Log("SoundControl is null.");
        }
    }

    public void Select(string levelName){
        SceneManager.LoadScene(levelName);

    }

    public void LoadGameLevel(string levelName){
        SceneName.NameOfTheScene = levelName;
        SceneManager.LoadScene("Loading Screen");
    }

    public static void setCurrentScene(){
        scene = SceneManager.GetActiveScene();
    }

    private void Update() {
        if(Input.GetKey(KeyCode.Escape) && scene.name == "Prison"){
            if (_soundControl)
            {
                _soundControl.stopInGameSound();
            }

            Select("Menu");
        }
    }

    public static Scene GetCurrentScene(){
        return scene;
    }
}
