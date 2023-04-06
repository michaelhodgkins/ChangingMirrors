using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI enemyCountText;
    public TextMeshProUGUI scoreText;
    public int waveNumber = 1;
    public int enemyCount = 1;
    public float spawnPointX = 15;
    public float spawnPointZ = 15;
    public float score;
    public bool isGameActive;
    // Start is called before the first frame update

    
    void Start()
    {
        isGameActive = true;
        if(isGameActive)
        {
            SpawnEnemyWave(waveNumber);
            waveText.text = "Wave: " + waveNumber;
            enemyCount = FindObjectsOfType<Enemy>().Length;
            enemyCountText.text = "Remaining" + enemyCount;
            scoreText.text = "Score: " + score;
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if(isGameActive)
        {
            enemyCount = FindObjectsOfType<Enemy>().Length;
            enemyCountText.text = "Remaining: " + enemyCount;
            scoreText.text = "Score: " + score;


            if (enemyCount == 0)
            {
                waveNumber++;
                waveText.text = "Wave: " + waveNumber;
                SpawnEnemyWave(waveNumber);
                score += 10;
            }
        }
        if(waveNumber == 5) 
        {
            SceneManager.LoadScene("Main Menu");

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

