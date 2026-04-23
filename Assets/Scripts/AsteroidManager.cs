using UnityEngine;
using System.Collections.Generic;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField]
    private int m_maximumAsteroids;

    [SerializeField]
    private List<GameObject> m_asteroidsPrefabs;
}
