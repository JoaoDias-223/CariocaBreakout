using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameMenu : MonoBehaviour
{
    public void GoToLevelSelect(string levelName) {
        SceneManager.LoadScene(levelName);
    }
}
