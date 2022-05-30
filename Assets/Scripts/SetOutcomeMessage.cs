using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetOutcomeMessage : MonoBehaviour
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
        if (game.DidWin())
        {
            text.text = "VOCE VENCEU!";
        }
        else if (game.DidLose())
        {
            text.text = "VOCE PERDEU!";
        }
    }

    public void ResetOnLose()
    {
        text.text = "";
    }
}
