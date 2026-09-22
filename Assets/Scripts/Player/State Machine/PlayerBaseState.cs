using System;
using UnityEngine;

public abstract class PlayerBaseState : State
{
    // References
    protected Player player;
    protected InputReader input;
    
    protected readonly PlayerStateMachine stateMachine;

    protected PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;

        // Assign references
        player = stateMachine.player;
        input = stateMachine.input;
    }
}
