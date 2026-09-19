using Unity.VisualScripting;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{    
    private void Start()
    {
        SwitchState(new PlayerMoveState(this));
    }
}
