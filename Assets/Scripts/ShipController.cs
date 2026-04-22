using UnityEngine;

public class ShipController : MonoBehaviour
{

    private Rigidbody m_rigidbody;

    void Awake() {
        m_rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }



}
