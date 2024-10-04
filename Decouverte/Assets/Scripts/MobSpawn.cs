using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawn : MonoBehaviour
{

    public GameObject enemyPrefab;
    public Transform spawnPoint;  // Le point de spawn ext�rieur au chemin
    public float spawnInterval = 2f;
    public Transform[] waypoints; // Passer les waypoints au prefab

    void Start()
    {
        // Appelle la m�thode SpawnEnemy de mani�re r�p�t�e � des intervalles r�guliers
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (enemyPrefab != null && spawnPoint != null)
        {
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            enemy.GetComponent<MobMovement>().waypoints = waypoints; // Transf�rer les waypoints � l'ennemi
        }
    }
}
