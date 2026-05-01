using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : BoundedEntity
{
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
    private GameObject m_bulletPrefb;
    [SerializeField]
    private float m_fireDelay;
    [SerializeField]
    private float m_fireCount;
    [SerializeField]
    private bool m_isFiring;


    void Awake() {
     m_rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue value)
    {
        Vector2 moveInputDirection = value.Get<Vector2>();

        m_turnInput = moveInputDirection.x;
        m_forwardInput = moveInputDirection.y;

    }

    void OnAttack(InputValue value) {
        m_isFiring = value.Get<float>() > 0f;
    }

    protected override void LateUpdate() {

        m_rigidbody.rotation -= (m_turnInput * (m_turnSpeed * 100f)) * Time.deltaTime;

        if (m_forwardInput > 0)
        {
            m_rigidbody.AddRelativeForceY((m_forwardInput * (m_moveSpeed * 100f)) * Time.deltaTime);
        }
        else if (m_forwardInput < 0)
        {
            m_rigidbody.linearVelocity = Vector2.Lerp(m_rigidbody.linearVelocity, Vector2.zero, m_stoppingPower * Time.deltaTime);
        }

        if (m_rigidbody.linearVelocity.magnitude > m_maxSpeed)
        {
            m_rigidbody.linearVelocity = m_rigidbody.linearVelocity.normalized * m_maxSpeed;
        }

        base.LateUpdate();

        if (m_isFiring)
        {
            TrySpawnBullet();
        }
        else
        {
            m_fireCount = m_fireDelay;
        }

    }

    void TrySpawnBullet() {
        if (m_fireCount >= m_fireDelay)
        {
            m_fireCount = 0;

            GameObject bullet = GameObject.Instantiate(m_bulletPrefb);
            bullet.transform.position = transform.position + (transform.up * 3f);
            bullet.transform.up = transform.up;
        }
        else
        {
            m_fireCount += Time.deltaTime;
        }
    }
}


