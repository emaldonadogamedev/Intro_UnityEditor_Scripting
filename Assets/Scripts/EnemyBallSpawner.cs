using System.Collections.Generic;
using UnityEngine;

public class EnemyBallSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject m_leftClickBall;

    [SerializeField]
    private GameObject m_rightClickBall;

    [SerializeField]
    private List<GameObject> m_spawnPositions = new();

    [SerializeField]
    private float m_spawnForce = 850f;

    [SerializeField]
    private float m_enemyBallSpawnCooldown = 2f;

    private float m_enemyBallSpawnTimer = 0f;

#if UNITY_EDITOR
    // TODO: Add any properties needed to access component data in editor mode
#endif

    // Update is called once per frame
    private void Update()
    {
        m_enemyBallSpawnTimer += Time.deltaTime;
        if (m_enemyBallSpawnTimer < m_enemyBallSpawnCooldown)
        {
            return;
        }

        SpawnNewEnemyBall();
    }

    private void SpawnNewEnemyBall()
    {
        Vector3 newEnemyBallPosition =
            m_spawnPositions[Random.Range(0, m_spawnPositions.Count - 1)].transform.position;

        GameObject newEnemyBallPrefab = m_leftClickBall;
        if (Random.Range(1, 100) > 50)
        {
            newEnemyBallPrefab = m_rightClickBall;
        }

        GameObject newEnemyBall =
            Instantiate(newEnemyBallPrefab, newEnemyBallPosition, Quaternion.identity);

        newEnemyBall.GetComponent<Rigidbody>().AddForce(-transform.forward * m_spawnForce);

        m_enemyBallSpawnTimer = 0f;
    }
}
