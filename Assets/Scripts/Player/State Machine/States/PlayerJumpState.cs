using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public PlayerJumpState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    private float jumpTimer;

    public override void Enter()
    {
        Debug.Log("Entering 'Jump State'");

        jumpTimer = 0f;
        player.MovePlayerUp();

        // Set Player State
        player.SetState(PlayerState.jumping);

        // Set Animation State
        player.SetAnimation("Jump");

        // Subscribe Listeners
        input.MoveLeftPerformed += player.MovePlayerLeft;
        input.MoveRightPerformed += player.MovePlayerRight;
    }

    public override void Tick()
    {
        if(jumpTimer < player.jumpTime)
        {
            //jumpTimer += (float)AudioSettings.dspTime;
            jumpTimer += Time.deltaTime;
        }
        else
        {
            stateMachine.SwitchToMoveState();
        }
    }

    public override void Exit()
    {
        Debug.Log("Exiting 'Jump State'");

        player.MovePlayerDown();

        // Unsubscribe Listeners
        input.MoveLeftPerformed -= player.MovePlayerLeft;
        input.MoveRightPerformed -= player.MovePlayerRight;
    }
}

