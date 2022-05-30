using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneName : MonoBehaviour
{
    public static string NameOfTheScene = "null";

    public void SetNameOfTheScene(string name){
        NameOfTheScene = name;
    }

    public string GetNameOfTheScene(){
        return NameOfTheScene;
    }

}
