using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    private Rigidbody2D m_rigidbody;
    private float m_turnInput;
    private float m_forwardInput;
    private float m_turnSpeed;
    private float m_moveSpeed;

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

    public int targetFrameRate = 60;

    private void LateUpdate() {

        m_rigidbody.rotation -= (m_turnInput * (m_turnSpeed * 100f)) * Time.deltaTime;
        m_rigidbody.AddRelativeForceY((m_forwardInput * m_moveSpeed) * Time.deltaTime);

    }

}


