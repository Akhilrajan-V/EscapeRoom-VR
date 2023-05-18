using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Controller1 : MonoBehaviour
{
    // Start is called before the first frame update
    public bool solved = false;

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("booki"))
        {
            solved = true;
        }
    }
}
