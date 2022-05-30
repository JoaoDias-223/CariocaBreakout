using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FontController : MonoBehaviour
{
    [SerializeField]
    private int labelFontSize;

    [SerializeField]
    private int valueFontSize;

    [SerializeField]
    private TMPro.TMP_FontAsset asset = null;

    [SerializeField]
    private Color fontColor = Color.black;

    public int getLabelFontSize(){
        return labelFontSize;
    }

    public int getValueFontSize(){
        return valueFontSize;
    }

    public void setLabelFontSize(int size){
        labelFontSize = size;
    }

    public void setValueFontSize(int size){
        valueFontSize = size;
    }

    public TMPro.TMP_FontAsset getFontAsset(){
        return asset;
    }

    public Color getFontColor(){
        return fontColor;
    }
}
