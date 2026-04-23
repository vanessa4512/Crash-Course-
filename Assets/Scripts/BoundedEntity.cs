using UnityEngine;

public class BoundedEntity : MonoBehaviour
{
    protected Rigidbody2D m_rigidbody;

    [SerializeField]
    protected Rect m_bounds;

    void Awake() {
        m_rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    protected virtual void LateUpdate() {
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
