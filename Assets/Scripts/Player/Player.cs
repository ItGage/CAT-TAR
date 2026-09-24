using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public enum PlayerState { baseState, jumping, parrying, hit }

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerState currentState;
    
    [Header("Player Components")]
    [SerializeField] private Health playerHealth;
    [SerializeField] private InputReader playerInput;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private PlayerStateMachine playerStateMachine;
    [SerializeField] private GameObject playerSprite;
    [SerializeField] private GameObject playerCollider;
    [SerializeField] private AttackMeter attackMeter;

    [Header("Movement Variables")]
    public bool canBeHit;
    [Space(5)]
    public float moveDistance;
    public float moveLerpTime;
    [Space(5)]
    public float jumpDistance;
    public float jumpTime;
    [Space(5)]
    public float parryTime;
    [Space(5)]
    public float hitTime;

    // Private References
    private Vector2 playerStartingPos, desiredPosition;
    private float leftBounds, rightBounds;
    private Vector2 playerPos => playerSprite.transform.position;

    private void Start()
    {
        playerStartingPos = transform.position;

        leftBounds = (playerStartingPos.x - (moveDistance * 2f)) - 1f;
        rightBounds = (playerStartingPos.x + (moveDistance * 2f)) + 1f;
    }

    public void SetInvincibility(bool hit)
    {
        canBeHit = hit;
    }

    public void RegisterHit()
    {
        playerStateMachine.SwitchToHitState();
    }

    #region Setters

    public void SetState(PlayerState state)
    {
        currentState = state;
    }

    public void SetAnimation(String animationName)
    {
        playerAnimator.Play(animationName);
    }

    #endregion

    #region Getters

    public PlayerState GetState()
    {
        return currentState;
    }

    public Health GetHealth()
    {
        return playerHealth;
    }

    public InputReader GetInput()
    {
        return playerInput;
    }

    public Animator GetAnimator()
    {
        return playerAnimator;
    }

    public AttackMeter GetAttackMeter()
    {
        return attackMeter;
    }

    #endregion

    #region "Playing" Functions

    public void PlayUp()
    {
        SetAnimation("PlayUp");
    }

    public void PlayLeft()
    {
        SetAnimation("PlayLeft");
    }

    public void PlayRight()
    {
        SetAnimation("PlayRight");
    }

    public void PlayDown()
    {
        SetAnimation("PlayDown");
    }

    #endregion

    #region Movement Functions

    public void MovePlayerUp()
    {
        desiredPosition = new Vector2(playerPos.x, playerPos.y + jumpDistance);

        StartCoroutine(LerpSpritePosition(playerPos, desiredPosition, moveLerpTime));
    }

    public void MovePlayerLeft()
    {
        desiredPosition = new Vector2(playerPos.x - moveDistance, playerPos.y);

        if (desiredPosition.x > leftBounds)
        {
            MoveCollider(desiredPosition);
            StartCoroutine(LerpSpritePosition(playerPos, desiredPosition, moveLerpTime));
        }
    }

    public void MovePlayerRight()
    {
        desiredPosition = new Vector2(playerPos.x + moveDistance, playerPos.y);

        if (desiredPosition.x < rightBounds)
        {
            MoveCollider(desiredPosition);
            StartCoroutine(LerpSpritePosition(playerPos, desiredPosition, moveLerpTime));
        }
    }

    public void MovePlayerDown()
    {
        desiredPosition = new Vector2(playerPos.x, playerPos.y - jumpDistance);

        StartCoroutine(LerpSpritePosition(playerPos, desiredPosition, moveLerpTime));
    }

    public void MoveCollider(Vector2 pos)
    {
        playerCollider.transform.position = pos;
    }

    IEnumerator LerpSpritePosition(Vector2 startPos, Vector2 endPos, float timeLimit)
    {
        float elapsedTime = 0f;

        while(elapsedTime < timeLimit)
        {
            float t = elapsedTime / timeLimit;

            playerSprite.transform.position = Vector3.Lerp(startPos, endPos, t);

            elapsedTime += Time.deltaTime;
            //elpasedTime += AudioSource.dspTime;

            yield return null;
        }

        playerSprite.transform.position = endPos;
    }

    #endregion
}
