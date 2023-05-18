using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_xo_Controller : MonoBehaviour
{   

    public GameObject cross; 
    // Start is called before the first frame update
    void Start()
    {
        cross.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("cross1")) 
        {
            Destroy(GameObject.FindWithTag("crossp1"));
        }
        if(other.CompareTag("cross2"))
        {
            Destroy(GameObject.FindWithTag("crossp2"));
        }
        cross.SetActive(true);
    }
}
