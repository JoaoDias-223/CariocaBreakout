using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleKeyboard : MonoBehaviour
{
    private TouchScreenKeyboard keyboard;

    public void showKeyboard(){
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.NumbersAndPunctuation, false, false, false, false, "", 7);
    }

    public void hideKeyboard(){
        keyboard.active = false;
    }
}
