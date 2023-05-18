using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Controller3 : MonoBehaviour
{
    // Start is called before the first frame update
    public bool solved = false;

    // Update is called once per frame

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("bookA"))
        {
            solved = true;
        }
    }
}
