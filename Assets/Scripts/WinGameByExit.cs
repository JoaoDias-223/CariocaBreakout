using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGameByExit : MonoBehaviour
{
    [SerializeField] private GameController game;

    void Start()
    {
        game = Utils.FindObjectOfType<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.name == "Player")
        {
            game.Won();
        }
    }
}
