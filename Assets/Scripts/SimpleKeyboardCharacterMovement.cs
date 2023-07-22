using UnityEngine;

public class SimpleKeyboardCharacterMovement : MonoBehaviour
{
    // TODO: does this need to be public?
    // TODO: Additional attributes?
    public float m_moveSpeed = 5f; // Character movement speed

    // TODO: does this need to be public?
    // TODO: Additional attributes?
    public float m_rotationSpeed = 30f;

    private Vector3 m_direction = Vector3.zero;

    private float m_horizontalInput = 0f;
    private float m_verticalInput = 0f;

#if UNITY_EDITOR

    // TODO: Add necessary properties to access data in editor mode

#endif

    private void Update()
    {
        UpdateMovement();

        UpdateRotation();
    }

    private void UpdateMovement()
    {
        // A and D keys
        m_horizontalInput = Input.GetAxis("Horizontal");

        // W and S keys
        m_verticalInput = Input.GetAxis("Vertical");

        m_direction.x = m_horizontalInput;
        m_direction.z = m_verticalInput;

        // Normalize the movement vector to prevent faster diagonal movement
        m_direction.Normalize();

        // Move the character on the X and Z axis
        transform.Translate(m_direction * (m_moveSpeed * Time.deltaTime));
    }

    private void UpdateRotation()
    {
        float rotationMultiplier = 0f;
        if(Input.GetKey(KeyCode.Q))
        {
            rotationMultiplier = -1f;
        }
        else if(Input.GetKey(KeyCode.E))
        {
            rotationMultiplier = 1f;
        }
        transform.Rotate(
            Vector3.up,
            rotationMultiplier * m_rotationSpeed * Time.deltaTime);
    }
}
