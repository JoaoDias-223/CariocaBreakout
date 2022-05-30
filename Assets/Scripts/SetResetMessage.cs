using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetResetMessage : MonoBehaviour
{
    [SerializeField] private GameController game;
    private TMP_Text text;

    private void Start()
    {
        text = GetComponent<TMP_Text>();

        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (game.DidWin() || game.DidLose())
        {
            text.text = "Pressione R para recomecar";
        }
    }

    public void ResetOnLose()
    {
        text.text = "";
    }
}
