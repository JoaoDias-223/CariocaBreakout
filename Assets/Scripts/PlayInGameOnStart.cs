using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SoundControl))]
public class PlayInGameOnStart : MonoBehaviour
{
    private SoundControl _soundControl;
    // Start is called before the first frame update
    void Start()
    {
        _soundControl = Object.FindObjectOfType<SoundControl>();
        if(_soundControl == null){
            Debug.Log("SoundControl is null.");
            return;
        }

        _soundControl.playInGameSound();
    }
}
