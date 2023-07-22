using UnityEngine;

public class AutoDestroyAfterTimer : MonoBehaviour
{
    [Min(1f)]
    [SerializeField]
    [Header("Time alive in seconds (s)")]
    private float m_autoDestroyTime = 3f;

    private void Update()
    {
        m_autoDestroyTime -= Time.deltaTime;

        if (m_autoDestroyTime <= 0f)
        {
            Destroy(gameObject);
        }
    }
}