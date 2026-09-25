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
    [SerializeField] private GameObject boxCollider;
    [SerializeField] private GameObject edgeCollider;
    [SerializeField] private AttackMeter attackMeter;

    [Header("Movement Variables")]
    public bool isMoving;
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
    private Vector2 playerStartingPos, desiredPositionPlayer, desiredPositionEdge;
    private float leftBounds, rightBounds, upBounds, downBounds;
    private Vector2 playerPos => playerSprite.transform.position;
    private Vector2 edgePos => edgeCollider.transform.position;

    private void Start()
    {
        playerStartingPos = playerSprite.transform.position;

        leftBounds = playerStartingPos.x - (moveDistance * 2f);
        rightBounds = playerStartingPos.x + (moveDistance * 2f);
        upBounds = playerStartingPos.y + jumpDistance;
        downBounds = playerStartingPos.y;
    }

    private void Update()
    {
        if (playerPos.y != playerStartingPos.y && currentState != PlayerState.jumping)
        {
            MovePlayerDown();
        }
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
        desiredPositionPlayer = new Vector2(playerPos.x, playerPos.y + jumpDistance);

        if(desiredPositionPlayer.y <= upBounds && !isMoving)
        {
            StartCoroutine(LerpSpritePosition(playerPos, desiredPositionPlayer, moveLerpTime));
        }
    }

    public void MovePlayerLeft()
    {
        desiredPositionPlayer = new Vector2(playerPos.x - moveDistance, playerPos.y);
        desiredPositionEdge = new Vector2(edgePos.x - moveDistance, edgePos.y);

        if (desiredPositionPlayer.x >= leftBounds && !isMoving)
        {
            MoveBoxCollider(desiredPositionPlayer);
            MoveEdgeCollider(desiredPositionEdge);
            StartCoroutine(LerpSpritePosition(playerPos, desiredPositionPlayer, moveLerpTime));
        }
    }

    public void MovePlayerRight()
    {
        desiredPositionPlayer = new Vector2(playerPos.x + moveDistance, playerPos.y);
        desiredPositionEdge = new Vector2(edgePos.x + moveDistance, edgePos.y);

        if (desiredPositionPlayer.x <= rightBounds && !isMoving)
        {
            MoveBoxCollider(desiredPositionPlayer);
            MoveEdgeCollider(desiredPositionEdge);
            StartCoroutine(LerpSpritePosition(playerPos, desiredPositionPlayer, moveLerpTime));
        }
    }

    public void MovePlayerDown()
    {
        desiredPositionPlayer = new Vector2(playerPos.x, playerPos.y - jumpDistance);

        if(desiredPositionPlayer.y >= downBounds && !isMoving)
        {
            StartCoroutine(LerpSpritePosition(playerPos, desiredPositionPlayer, moveLerpTime));
        }
    }

    public void MoveBoxCollider(Vector2 pos)
    {
        boxCollider.transform.position = pos;
    }

    public void MoveEdgeCollider(Vector2 pos)
    {
        edgeCollider.transform.position = pos;
    }

    IEnumerator LerpSpritePosition(Vector2 startPos, Vector2 endPos, float timeLimit)
    {
        isMoving = true;
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
        isMoving = false;
    }

    #endregion
}
