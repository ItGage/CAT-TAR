using UnityEngine;

public class PlayerParryState : PlayerBaseState
{
    public PlayerParryState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    private float parryTimer;

    public override void Enter()
    {
        Debug.Log("Entering 'Parry State'");

        parryTimer = 0f;

        // Set Player State
        player.SetState(PlayerState.parrying);

        // Set Animation State
        player.SetAnimation("Parry");
    }

    public override void Tick()
    {
        if (parryTimer < player.parryTime)
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
    }
}