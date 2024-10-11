using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetEnemy : MonoBehaviour
{

    List<GameObject> targets = new List<GameObject>();
    bool isShooting = false;
    bool corountineIsRunning = false;
    public Transform teteTourelle;
    //GameObject currentTarget;
    public GameObject bulletPrefab;

    private void Start()
    {
        corountineIsRunning=true;
        //StartCoroutine(ShotTheEnemy());
        StartCoroutine(LookAtEnemy());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Enemy")
        {
            targets.Add(other.gameObject);
            if (!isShooting)
            {
                StartCoroutine(ShotTheEnemy());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag=="Enemy")
        {
            if (targets.Contains(other.gameObject))
            {
                targets.Remove(other.gameObject);
            }

            if (targets.Count==0)
            {
                isShooting = false;
            }
        }
    }

    public IEnumerator ShotTheEnemy()
    {
        isShooting = true;
        while (corountineIsRunning)
        {
            while(targets.Count>0)
            {
                if (targets[0] != null)
                {
                    // Créer une balle
                    GameObject bullet = Instantiate(bulletPrefab, teteTourelle.position, Quaternion.identity);
                    // Définir la cible pour la balle
                    bullet.GetComponent<BulletMovement>().SetTarget(targets[0].transform);
                    // Infliger des dégâts à l'ennemi
                    //targets[0].GetComponent<HealthPoint>().healthPoints -= 10;
                    yield return new WaitForSeconds(1f);
                }
            }
            yield return null;
        }
        isShooting = false;
    }

    public IEnumerator LookAtEnemy()
    {
        while (corountineIsRunning)
        {
            if (targets.Count>0)
            {
                teteTourelle.transform.LookAt(targets[0].transform.position);
            }
            yield return null;
        }
        yield return null;
    }

}
