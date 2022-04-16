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
    [Space]
    [SerializeField] private float shootWaitTime = 0.5f;
    [SerializeField] private float moveWaitTime = 0.3f;
    private float waitBeforeShooting;
    private float waitBeforeMoving;
    private bool canMove = true;
    private Vector3 tempPos;
    private float xAxis;
    private float yAxis;
    private PlayerAnimation playerAnimation;
    private PlayerShootingManager playerShootingManager;
    private void Awake()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
        playerShootingManager = GetComponent<PlayerShootingManager>();
    }
    private void Update()
    {
        HandleMovement();
        HandleAnimation();

        HandleFacingDirection();

        HandleAndShooting();
        CheckIfCanMove();
    }
    private void HandleMovement()
    {
        xAxis = Input.GetAxisRaw(TagManager.Horizontal);
        yAxis = Input.GetAxisRaw(TagManager.Vertical);
        if(!canMove)
        {
            return;
        }

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
        if(!canMove)
        {
            return;
        }
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
    private void StopMovement()
    {
        canMove = false;
        waitBeforeMoving = Time.time + moveWaitTime;
    }
    private void Shoot()
    {
        waitBeforeShooting = Time.time + shootWaitTime;
        StopMovement();
        playerAnimation.PlayAnimation(TagManager.ShootAnimationName);

        playerShootingManager.Shoot(transform.localScale.x);
    }
    private void CheckIfCanMove() 
    {
        if(Time.time > waitBeforeMoving)
        {
            canMove = true; 
        }
    }
    private void HandleAndShooting()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(Time.time > waitBeforeShooting)
            {
                Shoot();
            }
        }
    }
}
