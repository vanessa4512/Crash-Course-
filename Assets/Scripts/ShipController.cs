using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    private Rigidbody2D m_rigidbody;
    private float       m_turnInput;
    private float       m_forwardInput;

    [SerializeField]
    private float m_maxSpeed;
    [SerializeField]
    private float m_turnSpeed;
    [SerializeField]
    private float m_moveSpeed;
    [SerializeField]
    private float m_stoppingPower;
    [SerializeField]
    private Rect m_bounds;



    void Awake() {
        m_rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue value)
    {
        Vector2 moveInputDirection = value.Get<Vector2>();

        m_turnInput = moveInputDirection.x;
        m_forwardInput = moveInputDirection.y;

    }

    void OnAttack() {
        Debug.Log("Attack me");
    }

    private void LateUpdate() {

        m_rigidbody.rotation -= (m_turnInput * (m_turnSpeed * 100f)) * Time.deltaTime;

        if (m_forwardInput > 0)
        {
            m_rigidbody.AddRelativeForceY((m_forwardInput * (m_moveSpeed * 100f))* Time.deltaTime);
        }
        else if (m_forwardInput < 0)
        {
            m_rigidbody.linearVelocity = Vector2.Lerp(m_rigidbody.linearVelocity,Vector2.zero, m_stoppingPower * Time.deltaTime);
        }

        if (m_rigidbody.linearVelocity.magnitude > m_maxSpeed)
        {
            m_rigidbody.linearVelocity = m_rigidbody.linearVelocity.normalized * m_maxSpeed;
        }

        if (!m_bounds.Contains(transform.position))
        {
            Vector2 position = transform.position;

            if (position.x < m_bounds.xMin)
            {
                position.x = m_bounds.xMax;
            }

            if (position.x > m_bounds.xMax)
            {
                position.x = m_bounds.xMin;
            }

            if (position.y < m_bounds.yMin)
            {
                position.y = m_bounds.yMax;
            }

            if (position.y > m_bounds.yMax)
            {
                position.y = m_bounds.yMin;
            }
             m_rigidbody.position = position;

        }

    }

}


