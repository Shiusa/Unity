using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoint : MonoBehaviour
{
    [SerializeField]
    public int healthPoints
    {
        get
        {
            return healthPoints;
        }
        set
        {
            healthPoints = value;
            Debug.Log("Je viens de me faire tierer dessus, voici mes pv: " + healthPoints);
            SomeValueChangedFunction(healthPoints, value);
        }
    }

    public void SomeValueChangedFunction(int healthPoints, float value)
    {
        if (healthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        healthPoints = 100;
    }

}
