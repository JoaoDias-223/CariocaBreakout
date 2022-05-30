using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEditor;
using System.IO;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer BKGMixer, SFXMixer, IGMMixer;
    public Slider BKGSlider, SFXSlider, IGMSlider;
    public TMPro.TMP_Text BKGPercentage, SFXPercentage, IGMPercentage;

    private static float backgroundFloat, sfxFloat, igmFloat;

    private void Start() {
        BKGSlider.value = AudioManager.BKG_Volume;
        SFXSlider.value = AudioManager.SFX_Volume;
        IGMSlider.value = AudioManager.IGM_Volume;

        SetMusicVolume(AudioManager.BKG_Volume);
        SetSFXVolume(AudioManager.SFX_Volume);
        SetIGMVolume(AudioManager.IGM_Volume);
    }

    public void SetText(float value, TMPro.TMP_Text tmp_text)
    {
        int percentage = (int) ((value + 80.0f) * (100/80.0f));
        string text = percentage.ToString() + " %";
        //Debug.LogFormat("{0}: {1}", tmp_text.transform.parent.name,text);
        tmp_text.text = text;
    }

    public void SetMusicVolume(float volume){
        BKGMixer.SetFloat("volume", volume);
        SetText(volume, BKGPercentage);
        AudioManager.BKG_Volume = volume;
    }

    public void SetSFXVolume(float volume){
        SFXMixer.SetFloat("volume", volume);
        SetText(volume, SFXPercentage);
        AudioManager.SFX_Volume = volume;
    }

    public void SetIGMVolume(float volume){
        IGMMixer.SetFloat("volume", volume);
        SetText(volume, IGMPercentage);
        AudioManager.IGM_Volume = volume;
    }

    public void SaveSettings()
    {
        Debug.LogFormat("Saving setting:\n\tBKG: {0}  \n\tSFX:{1}  \n\tIGM: {2}", AudioManager.BKG_Volume, AudioManager.SFX_Volume, AudioManager.IGM_Volume);
        AudioManager.Save();
    }
}
