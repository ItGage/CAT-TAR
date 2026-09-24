using UnityEngine;

public class PlayerHitState : PlayerBaseState
{
    public PlayerHitState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        Debug.Log("Entering 'Hit State'");

        player.SetInvincibility(true);

        // Set Player State
        player.SetState(PlayerState.hit);

        // Set Animation State
        player.SetAnimation("Hit");
    }

    public override void Tick()
    {

    }

    public override void Exit()
    {
        Debug.Log("Exiting 'Hit State''");

        player.SetInvincibility(false);
    }
}