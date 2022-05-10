using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageArea : MonoBehaviour
{
    [SerializeField] private float deactivateWaitTime = 0.1f;
    private float deactivateTimer;

    [SerializeField] private LayerMask playerLayer;

    private bool canDealDamage;
    [SerializeField] private float damageAmount = 5f;
    private float radiusCircle = 1f;

    private void Awake()
    {
        gameObject.SetActive(false);
    }
    private void Update()
    {
        if(Physics2D.OverlapCircle(transform.position, radiusCircle, playerLayer))
        {
            if(canDealDamage)
            {
                canDealDamage = false;
            }
        }
        DetectiveDamageArea();
    }
    private void DetectiveDamageArea()
    {
        if(Time.time > deactivateTimer)
        {
            gameObject.SetActive(false);
        }
    }
    public void ResetDeatictivateTimer()
    {
        canDealDamage = true;
        deactivateTimer = Time.time + deactivateWaitTime;

    }
}
