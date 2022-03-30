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

    private Vector3 tempPos;
    private float xAxis;
    private float yAxis;

    private void Update()
    {
        HandleMovement();
    }
    private void HandleMovement()
    {
        xAxis = Input.GetAxisRaw(TagManager.Horizontal);
        yAxis = Input.GetAxisRaw(TagManager.Vertical);

        tempPos = transform.position;

        tempPos.x += xAxis * speed * Time.deltaTime;
        tempPos.y += yAxis * speed * Time.deltaTime;

        transform.position = tempPos;

    }
}
