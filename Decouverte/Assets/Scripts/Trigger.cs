using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject porte;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);
        porte.transform.Rotate(new Vector3(0, 90, 0));
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.gameObject);
        porte.transform.Rotate(new Vector3(0, -90, 0));
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
