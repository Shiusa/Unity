using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetEnemy : MonoBehaviour
{

    List<GameObject> targets = new List<GameObject>();
    bool alreadyShooting = false;
    bool corountineIsRunning = false;
    public Transform teteTourelle;
    //GameObject currentTarget;

    private void Start()
    {
        corountineIsRunning=true;
        StartCoroutine(ShotTheEnemy());
        StartCoroutine(LookAtEnemy());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Enemy")
        {
            targets.Add(other.gameObject);
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
        }
    }

    public IEnumerator ShotTheEnemy()
    {
        while (corountineIsRunning)
        {
            if(targets.Count>0)
            {

                targets[0].GetComponent<HealthPoint>().healthPoints -= 10;
                yield return new WaitForSeconds(1);
            }
            yield return null;
        }
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
