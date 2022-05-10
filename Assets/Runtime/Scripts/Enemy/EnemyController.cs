using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float stoppingDistance = 1.5f;

    [SerializeField] private float attactWaitTime = 2.5f;
    private float attackTimer;

    [SerializeField] private float attackFinesheWaitTime = 0.5f;
    private float attackFinesheWaitTimer;

    private Transform playerTarget;
    private Vector3 tempScale;
    private PlayerAnimation enemyAnimation;

    [SerializeField] private EnemyDamageArea enemyDamageArea;

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
            HandleFacingDirection();

        }
        else
        {
            CheckIfFinesheAttack();
            Attack();
        }
    }
    private void HandleFacingDirection()
    {
        tempScale = transform.localScale;
        if(transform.position.x > playerTarget.position.x)
        {
            tempScale.x = Mathf.Abs(tempScale.x);
        }
        else
        {
            tempScale.x = -Mathf.Abs(tempScale.x);
        }
        transform.localScale = tempScale;
    }
    private void CheckIfFinesheAttack()
    {
        if(Time.time > attackFinesheWaitTimer)
        {
            enemyAnimation.PlayAnimation(TagManager.IdleAnimationName);
        }
    }
    private void Attack()
    {
        if(Time.time > attackTimer)
        {
            attackFinesheWaitTimer = Time.time + attackFinesheWaitTime;
            attackTimer = Time.time + attackTimer;

            enemyAnimation.PlayAnimation(TagManager.AttackAnimationName);
        }
    }
    private void EnemyAttacked()
    {
        enemyDamageArea.gameObject.SetActive(true);
        enemyDamageArea.ResetDeatictivateTimer();
    }
}
