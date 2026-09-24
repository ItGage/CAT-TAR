using UnityEngine;

public class PlayerHitState : PlayerBaseState
{
    public PlayerHitState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    private float hitTimer;

    public override void Enter()
    {
        Debug.Log("Entering 'Hit State'");

        hitTimer = 0f;
        player.SetInvincibility(true);

        // Set Player State
        player.SetState(PlayerState.hit);

        // Set Animation State
        player.SetAnimation("Hit");
    }

    public override void Tick()
    {
        if (hitTimer < player.hitTime)
        {
            //jumpTimer += (float)AudioSettings.dspTime;
            hitTimer += Time.deltaTime;
        }
        else
        {
            stateMachine.SwitchToMoveState();
        }
    }

    public override void Exit()
    {
        Debug.Log("Exiting 'Hit State''");

        player.SetInvincibility(false);
    }
}