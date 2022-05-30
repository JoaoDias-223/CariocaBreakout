using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static readonly string MapScalePref = "Map Scale";
    public static readonly string MidDistancePref = "Mid Distance";
    public static readonly string FinalDistancePref = "Final Distance";
    public static float MapScale;
    public static float MidDistance;
    public static float FinalDistance;

    private void Awake() {
        MapScale = PlayerPrefs.GetFloat(MapScalePref, 1.0f);
        MidDistance = PlayerPrefs.GetFloat(MidDistancePref, 16.23f);
        FinalDistance = PlayerPrefs.GetFloat(FinalDistancePref, 22.47f);
        
        DontDestroyOnLoad(this);
    }

    public static void RandScale(){
        //MapScale = Random.Range(1.0f, 1.5f);
        MapScale = 1.0f;
        PlayerPrefs.SetFloat(MapScalePref, MapScale);
    }

}