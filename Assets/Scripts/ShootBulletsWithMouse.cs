using UnityEngine;

public class ShootBulletsWithMouse : MonoBehaviour
{
    [Header("Bullet settings...")]
    [SerializeField]
    private GameObject m_leftClickBullet;

    [SerializeField]
    private Transform m_leftClickBulletSpawnPosition;

    [SerializeField]
    private GameObject m_rightClickBullet;

    [SerializeField]
    private Transform m_rightClickBulletSpawnPosition;

    [SerializeField]
    private float m_bulletSpawnForce = 1000f;

#if UNITY_EDITOR

    //TODO: Add necessary properties to access information in editor mode

#endif

    void Update()
    {
        if (Input.GetMouseButtonDown(0))  // Left mouse button
        {
            Shoot(m_leftClickBullet, m_leftClickBulletSpawnPosition.position);
        }
        else if (Input.GetMouseButtonDown(1))  // Right mouse button
        {
            Shoot(m_rightClickBullet, m_rightClickBulletSpawnPosition.position);
        }
    }

    void Shoot(GameObject bulletPrefab, Vector3 spawnPosition)
    {
        // Instantiate the bullet prefab
        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);

        // Apply any additional logic or modifications to the bullet if needed

        // Add force or velocity to the bullet to make it move
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        // Adjust the force as needed
        bulletRigidbody.AddForce(transform.forward * m_bulletSpawnForce);
    }
}
