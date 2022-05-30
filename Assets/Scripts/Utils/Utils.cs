using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    public static GameObject GetChildWithName(GameObject obj, string name) {
        Transform trans = obj.transform;
        Transform childTrans = trans.Find(name);
        if (childTrans != null) {
            return childTrans.gameObject;
        } else {
            Debug.Log("Could not find " + name + " in " + obj.name);
            return null;
        }
    }

    public static void Hide(CanvasGroup canvasGroup) {
        canvasGroup.alpha = 0f;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
    }

    public static void Show(CanvasGroup canvasGroup) {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;
    }

    public static void Freeze(CanvasGroup canvasGroup){
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
    }

    public static void Unfreeze(CanvasGroup canvasGroup){
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;
    }

    public bool checkIfObjectIsStill(GameObject obj){

        bool ObjIsMoving = false;


        StartCoroutine(
            CheckMoving(
                obj, //gameobject
                (i)=> { ObjIsMoving = i; } //callback function
            )
        );

        return ObjIsMoving;
    }

    private IEnumerator CheckMoving(GameObject gmobj, System.Action<bool> callback)
    {
        Vector3 startPos = gmobj.transform.position;

        yield return new WaitForSeconds(1f);

        Vector3 finalPos = gmobj.transform.position;

        if( startPos.x != finalPos.x ||
            startPos.y != finalPos.y ||
            startPos.z != finalPos.z)
            {
                callback(true);
            }
        
        yield return 0;
    }

    public static string getBetween(string strSource, string strStart, string strEnd)
    {
        if (strSource.Contains(strStart) && strSource.Contains(strEnd))
        {
            int Start, End;
            Start = strSource.IndexOf(strStart, 0) + strStart.Length;
            End = strSource.IndexOf(strEnd, Start);
            return strSource.Substring(Start, End - Start);
        }

        return "";
    }

    public void ShowMessage(string msg, GameObject canvas, string message_container_name, string action_message_name){
        GameObject MessageContainer = Utils.GetChildWithName(canvas, message_container_name);
        GameObject message = Utils.GetChildWithName(MessageContainer, action_message_name);
        TMPro.TMP_Text messageTMP = message.GetComponent<TMPro.TMP_Text>();
        messageTMP.text = msg;
        messageTMP.color = new Color(154.0f/255.0f,0,0,1);
        ToggleUIElement MessageContainerUI = MessageContainer.GetComponent<ToggleUIElement>();
        MessageContainerUI.Show();
        StartCoroutine(HideMessage(4.0f, MessageContainerUI));
    }

    private IEnumerator HideMessage(float waitTime, ToggleUIElement uiElem)
    {
        yield return new WaitForSecondsRealtime(waitTime);
        uiElem.Hide();
    }
}
