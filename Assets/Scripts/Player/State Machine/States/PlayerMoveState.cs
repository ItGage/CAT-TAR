using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    public PlayerMoveState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        Debug.Log("Entering 'Move State'");

        // Set Player State
        player.SetState(PlayerState.baseState);

        // Set Animation State
        player.SetAnimation("Idle");

        // Subscribe Listeners
        stateMachine.input.JumpPerformed += stateMachine.SwitchToJumpState;
        stateMachine.input.ParryPerformed += stateMachine.SwitchToParryState;

        stateMachine.input.MoveLeftPerformed += player.MovePlayerLeft;
        stateMachine.input.MoveRightPerformed += player.MovePlayerRight;

        stateMachine.input.UpPerformed += player.PlayUp;
        stateMachine.input.LeftPerformed += player.PlayLeft;
        stateMachine.input.RightPerformed += player.PlayRight;
        stateMachine.input.DownPerformed += player.PlayDown;

    }

    public override void Tick()
    {

    }

    public override void Exit()
    {
        Debug.Log("Exiting 'Move State''");

        // Unsubscribe Listeners
        stateMachine.input.JumpPerformed -= stateMachine.SwitchToJumpState;
        stateMachine.input.ParryPerformed -= stateMachine.SwitchToParryState;

        stateMachine.input.MoveLeftPerformed -= player.MovePlayerLeft;
        stateMachine.input.MoveRightPerformed -= player.MovePlayerRight;

        stateMachine.input.UpPerformed -= player.PlayUp;
        stateMachine.input.LeftPerformed -= player.PlayLeft;
        stateMachine.input.RightPerformed -= player.PlayRight;
        stateMachine.input.DownPerformed -= player.PlayDown;
    }
}
