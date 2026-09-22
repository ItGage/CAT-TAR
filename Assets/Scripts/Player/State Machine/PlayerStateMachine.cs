using System;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;


public class PlayerStateMachine : StateMachine
{
    public Player player;
    public InputReader input;

    // State References
    private PlayerMoveState moveState;
    private PlayerJumpState jumpState;
    private PlayerParryState parryState;
    private PlayerHitState hitState;

    private void Start()
    {
        SwitchToMoveState();
    }

    #region State Switchers

    public void SwitchToMoveState()
    {
        if(moveState == null)
        {
            moveState = new PlayerMoveState(this);
        }

        SwitchState(moveState);
    }

    public void SwitchToJumpState()
    {
        if (jumpState == null)
        {
            jumpState = new PlayerJumpState(this);
        }

        SwitchState(jumpState);
    }

    public void SwitchToParryState()
    {
        if (parryState == null)
        {
            parryState = new PlayerParryState(this);
        }

        SwitchState(parryState);
    }

    public void SwitchToHitState()
    {
        if (hitState == null)
        {
            hitState = new PlayerHitState(this);
        }

        SwitchState(hitState);
    }

    #endregion
}
