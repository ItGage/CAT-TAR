using System;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected State currentState;

    public void SwitchState(State state)
    {
        currentState?.Exit();
        currentState = state;
        currentState?.Enter();
    }

    private void Update()
    {
        currentState?.Tick();
    }
}
