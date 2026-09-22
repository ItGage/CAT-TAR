using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private StateMachine playerStateMachine;
    [SerializeField] private InputReader playerInput;

    [Header("Movement Variables")]
    public float moveDistance;
    public float rightMaxDistance;
    public float leftMaxDistance;
    [Space(5)]
    public float jumpLength;
    public float jumpDistance;

    private float playerX;
    private float playerY;

    #region Movement Functions

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
        playerY = transform.position.y + jumpDistance;
        transform.position = new Vector2(transform.position.x, playerY);
    }

    public void MovePlayerDown()
    {
        playerY = transform.position.y - jumpDistance;
        transform.position = new Vector2(transform.position.x, playerY);
    }

    #endregion
}
