using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    public float speed = 20f;  // Vitesse de la balle
    private Transform target;

    // Méthode pour définir la cible
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            // Calculer la direction vers la cible
            Vector3 direction = (target.position - transform.position).normalized;
            // Déplacer la balle dans cette direction
            transform.position += direction * speed * Time.deltaTime;

            // Vérifie si la balle est assez proche de la cible pour la détruire (optionnel)
            if (Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                // Optionnel : appeler une méthode pour infliger des dégâts ici
                // target.GetComponent<HealthPoint>().healthPoints -= 10;

                // Détruire la balle
                //Destroy(gameObject);
            }
            Destroy(gameObject,5f);
        }
        else
        {
            // Détruire la balle si elle n'a pas de cible (optionnel)
            Destroy(gameObject);
        }
    }
}
