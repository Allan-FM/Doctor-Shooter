using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageArea : MonoBehaviour
{
    [SerializeField] private float deactivateWaitTime = 0.1f;
    private float deactivateWaitTimer;

    [SerializeField] private LayerMask playerLayer;

    private float radiusCircle = 1f;
    private void Update()
    {
        if(Physics2D.OverlapCircle(transform.position, radiusCircle, playerLayer))
        {
            Debug.Log("Deal damage to player");
        }
    }
}
