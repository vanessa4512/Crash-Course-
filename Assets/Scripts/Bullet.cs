using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float forwarmSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.position += (transform.up * forwarmSpeed) * Time.deltaTime;
    }
}
