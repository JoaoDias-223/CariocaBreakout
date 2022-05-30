using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class ToggleUIElement : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public bool isVisible = true;
    private bool shouldShow = false;
    
    private void Start() {
        if (canvasGroup.alpha > 0){
            isVisible = true;
            shouldShow = false;
        }
        else{
            isVisible = false;
            shouldShow = true;
        }
    }

    public void Hide() {
        Utils.Hide(canvasGroup);
        isVisible = false;
        shouldShow = true;
    }

    public void Show() {
        Utils.Show(canvasGroup);
        isVisible = true;
        shouldShow = false;
    }

    public void Toggle(){
        if(shouldShow){
            Show();
        }
        else{
            Hide();
        }
    }
}
