using System;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected State currentState;
    protected State prevState;

    public void SwitchState(State state)
    {
        currentState?.Exit();
        prevState = currentState;
        currentState = state;
        currentState?.Enter();
    }

    private void Update()
    {
        currentState?.Tick();
    }
}
