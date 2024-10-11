using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    public float speed = 20f;  // Vitesse de la balle
    private Transform target;

    // M�thode pour d�finir la cible
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
            // D�placer la balle dans cette direction
            transform.position += direction * speed * Time.deltaTime;

            // V�rifie si la balle est assez proche de la cible pour la d�truire (optionnel)
            if (Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                // Optionnel : appeler une m�thode pour infliger des d�g�ts ici
                // target.GetComponent<HealthPoint>().healthPoints -= 10;

                // D�truire la balle
                //Destroy(gameObject);
            }
            Destroy(gameObject,5f);
        }
        else
        {
            // D�truire la balle si elle n'a pas de cible (optionnel)
            Destroy(gameObject);
        }
    }
}
