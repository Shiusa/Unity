using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobMovement : MonoBehaviour
{

    public Transform[] waypoints;  // Waypoints définis par le spawner
    public float moveSpeed = 5f, rotationSpeed = 5f;
    int waypointIndex = 0;

    void Update()
    {
        // Si tous les waypoints sont parcourus, détruire l'objet
        if (waypointIndex >= waypoints.Length)
        {
            Destroy(gameObject);
            return;
        }

        // Calculer la direction vers le waypoint courant
        Vector3 direction = waypoints[waypointIndex].position - transform.position;

        // Vérifier si on est proche du waypoint, passer au suivant si oui
        if (direction.magnitude < 0.1f)
        {
            waypointIndex++;
        }
        else
        {
            // Rotation fluide vers le waypoint
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Déplacement vers le waypoint
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }
}
