using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ActionMessage : MonoBehaviour
{
    [SerializeField]
    private Color onSuccessColor = Color.black;
    [SerializeField]
    private Color onFailureColor = Color.black;

    static string successMessage = "ACAO BEM-SUCEDIDA";
    static string failureMessage = "ACAO FRACASSADA";

    private Animator animator = null;
    private TMPro.TMP_Text text = null;

    private string playAnimationName = "MessageGoingUpwards";

    public bool reset = false;

    private void Start() {
        animator = GetComponent<Animator>();
        text = GetComponent<TMPro.TMP_Text>();
        text.text = "";
    }

    public void playSuccessMessage(){
        //Debug.Log("success message");
        text.text = successMessage;
        text.color = onSuccessColor;
        //animator[playAnimationName].wrapMode = WrapMode.Once;
        animator.Play(playAnimationName);
        reset = false;
        //StartCoroutine(resetRoutine());
    }

    public void playFailureMessage(){
        //Debug.Log("failure message");
        text.text = failureMessage;
        text.color = onFailureColor;
        animator.Play(playAnimationName);
        reset = false;
        //StartCoroutine(resetRoutine());
    }

    public void resetTriggerPlay(){
        animator.ResetTrigger("play");
        reset = true;
    }

    IEnumerator resetRoutine(){
        yield return new WaitForSeconds(2);
        resetTriggerPlay();
        yield return 0;
    }
}
