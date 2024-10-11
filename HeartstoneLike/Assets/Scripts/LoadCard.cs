using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCard : MonoBehaviour
{
    private float startY;
    public Card card;
    public bool descending = false;
    public bool coroutine = false;
    // Start is called before the first frame update
    void Start()
    {
        startY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
