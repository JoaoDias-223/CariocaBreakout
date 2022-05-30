using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputFieldSwitcher : MonoBehaviour {
    public ToggleUIElement InputField01;
    public ToggleUIElement InputField02;

    public void SwitchFields(){
        if (InputField01.isVisible){
            InputField01.Hide();
            InputField02.Show();
        }
        else{
            InputField01.Show();
            InputField02.Hide();
        }
    }

    public void setFieldActive(ToggleUIElement inputField){
        InputField01.Hide();
        InputField02.Hide();
        inputField.Show();
    }
}