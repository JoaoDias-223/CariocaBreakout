using System;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public const int RUNNING = 0;
    public const int PAUSE = 1;
    public const int LOST = 2;
    public const int WIN = 3;
    [SerializeField] public int state = 0;

    public PlayerMovement player;
    public SetCurrentTime setCurrentTime;
    public SetOutcomeMessage setOutcomeMessage;
    public SetResetMessage setResetMessage;
    public Transform guardsParent;

    private List<GuardAiMovement> guards;

    private void Start()
    {
        guards = new List<GuardAiMovement>();

        foreach (Transform guard in guardsParent)
        {
            guards.Add(guard.transform.GetComponentInChildren<GuardAiMovement>());
        }
    }

    public bool IsRunning()
    {
        return state == RUNNING;
    }

    public bool DidWin()
    {
        return state == WIN;
    }

    public bool DidLose()
    {
        return state == LOST;
    }

    public void Won()
    {
        state = WIN;
    }

    public void Lost()
    {
        state = LOST;
    }

    public void Run()
    {
        state = RUNNING;
    }

    public void Reset()
    {
        player.ResetOnLose();
        setCurrentTime.ResetOnLose();
        setOutcomeMessage.ResetOnLose();
        setResetMessage.ResetOnLose();

        foreach (GuardAiMovement guard in guards)
        {
            guard.ResetOnLose();
        }

        Run();
    }
}
