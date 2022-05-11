using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Bounds")]
    [SerializeField] private float playerBoundsMinY = -1f;
    [SerializeField] private float playerBoundsMinX = -65f;
    [SerializeField] private float playerBoundsMaxX = 65f;

    [SerializeField] private float smoothSpeed = 2f;

    [SerializeField] private float Ygap = 2f;

    private Transform playerTarget;
    private Vector3 tempPos;

    private void Start()
    {
        playerTarget = GameObject.FindWithTag(TagManager.PlayerTag).transform;
    }
    private void Update()
    {
        if (!playerTarget)
        {
            return;
        }
        tempPos = transform.position;

        if (playerTarget.position.y <= playerBoundsMinY)
        {
            tempPos = Vector3.Lerp(transform.position, new Vector3(playerTarget.position.x,
                playerTarget.position.y, -10f), Time.time * smoothSpeed);
        }
        else
        {
            tempPos = Vector3.Lerp(transform.position, new Vector3(playerTarget.position.x,
                playerTarget.position.y + Ygap, -10f), Time.time * smoothSpeed);
        }
        if (tempPos.x > playerBoundsMaxX)
        {
            tempPos.x = playerBoundsMaxX;
        }
        if (tempPos.x < playerBoundsMinX)
        {
            tempPos.x = playerBoundsMinX;
        }

        transform.position = tempPos;
    }
}
