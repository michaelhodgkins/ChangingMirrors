using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public TextMeshProUGUI waveText;
    public int waveNumber = 1;
    public int enemyCount;
    public float spawnPointX = 15;
    public float spawnPointZ = 15;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if(enemyCount == 0 )
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
          
            Instantiate(enemyPrefab, RandomSpawnPoint(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 RandomSpawnPoint()
    {

        float randomSpawnX = Random.Range(-spawnPointX, spawnPointX);
        float randomSpawnZ = Random.Range(-spawnPointZ, spawnPointZ);

        Vector3 randomPos = new Vector3(randomSpawnX, 0, randomSpawnZ);

        return randomPos;
    }
}

