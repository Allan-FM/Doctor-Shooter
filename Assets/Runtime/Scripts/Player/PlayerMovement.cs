using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3.5f;

    [Header("Bounds")]
    [Space]
    [SerializeField] private float minBoundsX = -71f;
    [SerializeField] private float maxBoundsX = 71f;
    [SerializeField] private float minBoundsY = 3.7f;
    [SerializeField] private float maxBoundsY = 0f;

    [Header("Shoot")]
    [SerializeField] private float shootWaitTime = 0.5f;

    private Vector3 tempPos;
    private float xAxis;
    private float yAxis;
    private PlayerAnimation playerAnimation;

    private void Awake()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void Update()
    {
        HandleMovement();
        HandleAnimation();
        HandleFacingDirection();
    }
    private void HandleMovement()
    {
        xAxis = Input.GetAxisRaw(TagManager.Horizontal);
        yAxis = Input.GetAxisRaw(TagManager.Vertical);

        tempPos = transform.position;

        tempPos.x += xAxis * speed * Time.deltaTime;
        tempPos.y += yAxis * speed * Time.deltaTime;

        if(tempPos.y > maxBoundsY)
        {
            tempPos.y = maxBoundsY;
        }

        transform.position = tempPos;
    }
    private void HandleAnimation()
    {
        if(Mathf.Abs(xAxis) > 0 || Mathf.Abs(yAxis) > 0)
        {
            playerAnimation.PlayAnimation(TagManager.WalkAnimationName);
        }
        else
        {
            playerAnimation.PlayAnimation(TagManager.IdleAnimationName);
        }
    }
    private void HandleFacingDirection()
    {
        if(xAxis > 0)
        {
            playerAnimation.SetFacingirection(true);
        }
        else if(xAxis < 0)
        {
            playerAnimation.SetFacingirection(false);
        }
    }
}
