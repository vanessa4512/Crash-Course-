using UnityEngine;
public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float forwarmSpeed;

    [SerializeField]
    private float m_maximomLifetime;

    private float m_currentLifetime;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * (forwarmSpeed * Time.deltaTime);

        m_currentLifetime += Time.deltaTime;

        if (m_currentLifetime > m_maximomLifetime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D (Collider2D collision) {
        Destroy(gameObject);
    }
}
