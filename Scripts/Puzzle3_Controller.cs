using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3_Controlller : MonoBehaviour
{
    
    public Collider Socket; 

    public GameObject stairLight;
    public bool isConnected = false;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
       
        if (isConnected)
        {
            gameObject.transform.position = Socket.transform.position;
            gameObject.transform.rotation = Socket.transform.rotation;
            // DoorObject.isOpened = true;
            stairLight.SetActive(false);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other == Socket)
        {
            isConnected = true;
           
        }
        
    }
}
