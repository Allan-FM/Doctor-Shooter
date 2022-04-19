using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float stoppingDistance = 1.5f;
    private Transform playerTarget;
    private Vector3 tempScale;
    private PlayerAnimation enemyAnimation;

    private void Awake()
    {
        playerTarget = GameObject.FindWithTag(TagManager.PlayerTag).transform;
        enemyAnimation = GetComponent<PlayerAnimation>();
    }
    private void Update()
    {
        SearchForPlayer();
    }

    private void SearchForPlayer()
    {
        if(!playerTarget)
        {
            return;
        }
        if(Vector3.Distance(transform.position, playerTarget.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, 
                   playerTarget.position, moveSpeed * Time.deltaTime);

            enemyAnimation.PlayAnimation(TagManager.WalkAnimationName);
        }
        else
        {

        }

    }
}
