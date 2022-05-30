using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FontHandle : MonoBehaviour
{
    [SerializeField]
    private FontController fontController = null;
    // Start is called before the first frame update
    void Start()
    {
        GameObject label = Utils.GetChildWithName(this.gameObject, "Label");
        GameObject value = Utils.GetChildWithName(this.gameObject, "Value");

        TMPro.TMP_Text label_textM = label.GetComponent<TMPro.TMP_Text>();
        TMPro.TMP_Text value_textM = value.GetComponent<TMPro.TMP_Text>();

        label_textM.fontSize = fontController.getLabelFontSize();
        value_textM.fontSize = fontController.getValueFontSize();

        label_textM.font = fontController.getFontAsset();
        value_textM.font = fontController.getFontAsset();

        label_textM.color = fontController.getFontColor();
        value_textM.color = fontController.getFontColor();
    }
}
