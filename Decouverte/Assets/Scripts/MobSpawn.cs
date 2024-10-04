using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawn : MonoBehaviour
{

    public GameObject enemyPrefab;
    public Transform spawnPoint;  // Le point de spawn extérieur au chemin
    public float spawnInterval = 2f;
    public Transform[] waypoints; // Passer les waypoints au prefab

    void Start()
    {
        // Appelle la méthode SpawnEnemy de manière répétée à des intervalles réguliers
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (enemyPrefab != null && spawnPoint != null)
        {
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            enemy.GetComponent<MobMovement>().waypoints = waypoints; // Transférer les waypoints à l'ennemi
        }
    }
}
