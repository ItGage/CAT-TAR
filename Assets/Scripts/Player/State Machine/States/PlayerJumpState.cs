using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public PlayerJumpState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    private float jumpTimer;

    public override void Enter()
    {
        Debug.Log("Entering 'Jump State'");

        // Subscribe Listeners
        input.MoveLeftPerformed += player.MovePlayerLeft;
        input.MoveRightPerformed += player.MovePlayerRight;

        // Enter Logic
        jumpTimer = 0f;
        player.MovePlayerUp();
        player.SetInvincibility(true);
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

        // Unsubscribe Listeners
        input.MoveLeftPerformed -= player.MovePlayerLeft;
        input.MoveRightPerformed -= player.MovePlayerRight;

        // Exit Logic
        player.MovePlayerDown();
        player.SetInvincibility(false);
    }
}

