
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 15f;
    [SerializeField] private float damegeAmout = 35f;

    private Vector3 moveVector = Vector3.zero;
    private Vector3 tempScale;
    private void Update()
    {
        MoveBullet();
    }
    private void MoveBullet()
    {
        moveVector.x = moveSpeed * Time.deltaTime;
        transform.position += moveVector;
    }
    public void SetNegetiveSpeed()
    {
        moveSpeed *= -1f;
        tempScale = transform.localScale;
        tempScale.x = -tempScale.x;
        transform.localScale = tempScale;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(TagManager.EnemyTag))
        {

        }
    }
}
