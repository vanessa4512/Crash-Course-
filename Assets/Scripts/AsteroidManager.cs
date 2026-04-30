using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField]
    private int m_maximumAsteroids;

    [SerializeField]
    private List<GameObject> m_asteroidsPrefabs;

    [SerializeField]
    private Rect m_spawnArea;

    private void Start()
        {
            StartCoroutine(SpawnAsteroid());
        }

        private IEnumerator SpawnAsteroid() {
            for (int i = 0; i < m_maximumAsteroids; i++)
            {
                yield return new WaitForSeconds(0.1f);
                SpawnRandomAsteroid();
            }
        }


    private void SpawnRandomAsteroid()
    {
        int        index           = Random.Range(0, m_asteroidsPrefabs.Count);
        GameObject asteroidToSpawn = Instantiate(m_asteroidsPrefabs[index], transform);

        Vector2 spawnPoint = new Vector2(
                                         Random.Range(m_spawnArea.xMin, m_spawnArea.xMax),
                                         Random.Range(m_spawnArea.yMin, m_spawnArea.yMax)
                                        );
        asteroidToSpawn.transform.position = spawnPoint;

        AsteroidController controller = asteroidToSpawn.GetComponent<AsteroidController>();
        controller.onAsteroidDie += OnAsteroidDie;
    }

    private void OnAsteroidDie(AsteroidController obj) {
        Destroy(obj.gameObject);
    }
}
