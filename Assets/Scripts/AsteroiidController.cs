using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidController : BoundedEntity
{
    [SerializeField]
    private int m_size;

    [SerializeField]
    private float m_forcePower;
    [SerializeField]
    private float m_angularPower;

    public int size => m_size;
    public event Action<AsteroidController> onAsteroidDie;

    [SerializeField]
    private float m_health;

    private void Start() {
        m_rigidbody.AddForce(Random.insideUnitCircle * m_rigidbody.mass * m_forcePower, ForceMode2D.Impulse);
        m_rigidbody.angularVelocity = Random.Range(-m_angularPower, m_angularPower);
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        m_health--;
        if (m_health <= 0)
        {
            onAsteroidDie?.Invoke(this);
        }
    }
}
