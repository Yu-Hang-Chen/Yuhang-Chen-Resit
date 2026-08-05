using UnityEngine;
using System.Collections;

public class SpawnerControl : MonoBehaviour
{
   
    public GameObject enemyPrefab;      
    public float spawnInterval = 1f;   
    public int maxEnemies = 20;        

  
    public float activationRadius = 10f; 

    private bool isPlayerNearby = false;
    private Coroutine spawnCoroutine;
    private int currentEnemyCount = 0;

    void Start()
    {
        
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            if (spawnCoroutine == null)
            {
                spawnCoroutine = StartCoroutine(SpawnLoop());
            }
        }
    }

 
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;

            if (spawnCoroutine != null)
            {
                StopCoroutine(spawnCoroutine);
                spawnCoroutine = null;
            }
        }
    }

 
    IEnumerator SpawnLoop()
    {
        while (isPlayerNearby)
        {
            if (currentEnemyCount < maxEnemies)
            {
                SpawnEnemy();
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefab == null) return;

        Vector3 spawnPosition = transform.position;

        
        spawnPosition += new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));

        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        currentEnemyCount++;

    }

   
    public void OnEnemyDestroyed()
    {
        if (currentEnemyCount > 0)
            currentEnemyCount--;
    }
}