using System;
using UnityEngine;
using UnityEngine.UI;

public enum PlayerState { baseState, jumping, parrying, hit }

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerState currentState;
    
    [Header("Player Components")]
    [SerializeField] private Health playerHealth;
    [SerializeField] private StateMachine playerStateMachine;
    [SerializeField] private InputReader playerInput;

    [Header("Movement Variables")]
    public bool canBeHit;
    [Space(5)]
    public float moveDistance;
    public float rightMaxDistance;
    public float leftMaxDistance;
    [Space(5)]
    public float jumpLength;
    public float jumpTime;
    [Space(5)]
    public float parryTime;

    private float playerX;
    private float playerY;

    public void SetState(PlayerState state)
    {
        currentState = state;
    }

    public PlayerState GetState()
    {
        return currentState;
    }

    #region Movement Functions

    public void SetInvincibility(bool hit)
    {
        canBeHit = hit;
    }
    
    public void MovePlayerLeft()
    {

        playerX = transform.position.x - moveDistance;

        if (playerX > leftMaxDistance)
        {
            transform.position = new Vector2(playerX, transform.position.y);
        }
    }

    public void MovePlayerRight()
    {
        playerX = transform.position.x + moveDistance;

        if (playerX < rightMaxDistance)
        {
            transform.position = new Vector2(playerX, transform.position.y);
        }
    }

    public void MovePlayerUp() 
    {
        playerY = transform.position.y + jumpLength;
        transform.position = new Vector2(transform.position.x, playerY);
    }

    public void MovePlayerDown()
    {
        playerY = transform.position.y - jumpLength;
        transform.position = new Vector2(transform.position.x, playerY);
    }

    #endregion
}
