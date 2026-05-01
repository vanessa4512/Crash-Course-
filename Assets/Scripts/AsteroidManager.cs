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
    private int m_startingASteroids;

    [SerializeField]
    private int m_maximumAsteroids;

    [SerializeField]
    private List<GameObject> m_asteroidsPrefabs;

    [SerializeField]
    private int [] m_numToSpawnOnDeath;

    [SerializeField]
    private Rect m_spawnArea;

    [SerializeField]
    private float m_asteroidSpawnDelay;

    private int m_correntAsteroidCount;

    private void Start()
        {
            StartCoroutine(SpawnInitialAsteroids());
        }

        private IEnumerator SpawnInitialAsteroids() {
            for (int i = 0; i < m_startingASteroids; i++)
            {
                Vector2 spawnPoint = new Vector2();
                yield return new WaitForSeconds(0.1f);

                SpawnRandomAsteroid(3, GetSpawnPointRandom());
            }

            StartCoroutine(AsteroidSpawner());

        }

        private IEnumerator AsteroidSpawner() {
            while (m_correntAsteroidCount >= m_maximumAsteroids)
            {
                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForSeconds(0.1f);

            SpawnRandomAsteroid(3, GetSpawnPointRandom());

            StartCoroutine(AsteroidSpawner());
        }

        private Vector2 GetSpawnPointRandom() {
            Vector2 spawnPoint = new Vector2(
                                             Random.Range(m_spawnArea.xMin, m_spawnArea.xMax),
                                             Random.Range(m_spawnArea.yMin, m_spawnArea.yMax)
                                             );
            return spawnPoint;
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

        if (size == 3)
        {
            m_correntAsteroidCount--;
        }
    }

    private void OnAsteroidDie(AsteroidController asteroid) {
        int size = asteroid.size;
        Vector2 asteroidPoint =  asteroid.transform.position;

        Destroy(asteroid.gameObject);

        if (size == 3)
        {
            m_correntAsteroidCount--;
        }

        size--;

        int numToSpawn = m_numToSpawnOnDeath[size];

        if (size > 0)
        {
            for (int i = 0; i < numToSpawn; i++)
            {
                SpawnRandomAsteroid(size, (Random.insideUnitCircle * 5f) + asteroidPoint);
            }
        }
    }
}
