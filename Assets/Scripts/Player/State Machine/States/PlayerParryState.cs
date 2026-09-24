using UnityEngine;

public class PlayerParryState : PlayerBaseState
{
    public PlayerParryState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    private float parryTimer;

    public override void Enter()
    {
        Debug.Log("Entering 'Parry State'");

        // Set Player State
        player.SetState(PlayerState.parrying);

        // Set Animation State
        player.SetAnimation("Parry");

        // Enter Logic
        parryTimer = 0f;
        player.MovePlayerDown();
        player.SetInvincibility(true);
    }

    public override void Tick()
    {
        if (parryTimer < player.jumpTime)
        {
            //parryTimer += (float)AudioSettings.dspTime;
            parryTimer += Time.deltaTime;
        }
        else
        {
            stateMachine.SwitchToMoveState();
        }
    }

    public override void Exit()
    {
        Debug.Log("Exiting 'Parry State'");


        // Exit Logic
        player.MovePlayerUp();
        player.SetInvincibility(false);
    }
}