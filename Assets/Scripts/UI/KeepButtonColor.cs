using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class KeepButtonColor : MonoBehaviour
{
    public GameObject gameObjectButton;
    public GameObject joystick = null;
    public Color colorOnButtonPressed;
    public Color colorOnButtonReleased;

    private ToggleUIElement toggleUIElement;
    private Button button = null;
    private ColorBlock colorBlock;
    public Color corAtual;
    void Start(){
        button = gameObjectButton.GetComponent<Button>();
        toggleUIElement = joystick.GetComponent<ToggleUIElement>();
        colorBlock = button.colors;
        onButtonClick();
    }

    private void Update() {
        onButtonClick();
    }

    public void onButtonClick(){
        SetColors(getProperColor());
    }

    private Color getProperColor(){
        if (checkIfJoystickIsVisible()){
            return colorOnButtonPressed;
        }
        
        return colorOnButtonReleased;
    }

    private bool checkIfJoystickIsVisible(){
        if (toggleUIElement.isVisible){
            return true;
        }
        
        return false;
    }

    private void SetColors(Color color){
        colorBlock.normalColor = color;
        button.colors = colorBlock;
        corAtual = color;
    }
}
