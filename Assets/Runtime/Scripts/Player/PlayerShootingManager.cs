using UnityEngine;

public class PlayerShootingManager : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPositon;

    public void Shoot(float facingDirection)
    {
        GameObject newBullet = Instantiate(bulletPrefab, bulletSpawnPositon.position, Quaternion.identity);
        if(facingDirection < 0)
        {
            newBullet.GetComponent<Bullet>().SetNegetiveSpeed();
        }
    }
}
