using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField]
    private int m_maximumAsteroids;

    [SerializeField]
    private List<GameObject> m_asteroidsPrefabs;

    [SerializeField]
    private int [] m_numToSpawnOnDeath;

    [SerializeField]
    private Rect m_spawnArea;

    private void Start()
        {
            StartCoroutine(SpawnAsteroid());
        }

        private IEnumerator SpawnAsteroid() {
            for (int i = 0; i < m_maximumAsteroids; i++)
            {
                Vector2 spawnPoint = new Vector2();
                yield return new WaitForSeconds(0.1f);

                SpawnRandomAsteroid(3, spawnPoint);
            }
        }


    private void SpawnRandomAsteroid(int size, Vector2 spawnPoint)
    {
        IEnumerable<GameObject> sizePrefabs = m_asteroidsPrefabs.Where((x) =>x.GetComponent<AsteroidController>().size == size);
        if (sizePrefabs == null || sizePrefabs.Count() == 0)
        {
            return;
        }
        int        index           = Random.Range(0, sizePrefabs.Count());
        GameObject asteroidToSpawn = Instantiate(sizePrefabs.ElementAt(index), transform);

        spawnPoint = new Vector2(
                                         Random.Range(m_spawnArea.xMin, m_spawnArea.xMax),
                                         Random.Range(m_spawnArea.yMin, m_spawnArea.yMax)
                                        );
        asteroidToSpawn.transform.position = spawnPoint;

        AsteroidController controller = asteroidToSpawn.GetComponent<AsteroidController>();
        controller.onAsteroidDie += OnAsteroidDie;
    }

    private void OnAsteroidDie(AsteroidController asteroid) {
        int size = asteroid.size;
        Vector2 asteroidPoint =  asteroid.transform.position;

        Destroy(asteroid.gameObject);

        size--;

        int numToSpawn = m_numToSpawnOnDeath[size];

        if (size > 0)
        {
            for (int i = 0; i < numToSpawn; i++)
            {
                SpawnRandomAsteroid(size, (Random.insideUnitCircle * 2f) + asteroidPoint);
            }
        }
    }
}
