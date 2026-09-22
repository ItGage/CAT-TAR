using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    public PlayerMoveState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        Debug.Log("Entering 'Move State'");

        // Subscribe Listeners
        stateMachine.input.JumpPerformed += stateMachine.SwitchToJumpState;

        stateMachine.input.MoveLeftPerformed += player.MovePlayerLeft;
        stateMachine.input.MoveRightPerformed += player.MovePlayerRight;
    }

    public override void Tick()
    {

    }

    public override void Exit()
    {
        Debug.Log("Exiting 'Move State''");

        // Unsubscribe Listeners
        stateMachine.input.JumpPerformed -= stateMachine.SwitchToJumpState;

        stateMachine.input.MoveLeftPerformed -= player.MovePlayerLeft;
        stateMachine.input.MoveRightPerformed -= player.MovePlayerRight;
    }
}
