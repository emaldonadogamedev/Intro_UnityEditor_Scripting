using UnityEngine;

public enum BulletIdentifierType : byte
{
    none,
    leftClick,
    rightClick,
    leftClickEnemy,
    rightClickEnemy
}

public class BulletController : MonoBehaviour
{
    public BulletIdentifierType BulletIdentifierType => m_bulletIdentifierType;

    [SerializeField]
    private BulletIdentifierType m_bulletIdentifierType = BulletIdentifierType.none;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.TryGetComponent<BulletController>(out var otherBulletController))
            return;

        if(m_bulletIdentifierType == BulletIdentifierType.leftClick
            && otherBulletController.BulletIdentifierType == BulletIdentifierType.leftClickEnemy)
        {
            Destroy(gameObject);

            Destroy(collision.gameObject);
        }

        else if (m_bulletIdentifierType == BulletIdentifierType.rightClick
            && otherBulletController.BulletIdentifierType == BulletIdentifierType.rightClickEnemy)
        {
            Destroy(gameObject);

            Destroy(collision.gameObject);
        }
    }
}