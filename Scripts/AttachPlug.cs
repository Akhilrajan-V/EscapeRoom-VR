using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPlug : MonoBehaviour
{
    // public Transform initialTransform;

    public WireCircuit_Controller master;

    public GameObject correctSocket;
    string correctTag;
    float initial_x;
    float initial_y;
    float initial_z;
    // Start is called before the first frame update
    void Start()
    {
        initial_x = transform.position.x;
        initial_y = transform.position.y;
        initial_z = transform.position.z;
        correctTag  = correctSocket.tag; 
    }

    // Update is called once per frame
    void Update()
    {
        if(master.reset)
        {
            transform.position = new Vector3(initial_x, initial_y, initial_z);
            Debug.Log("Reset pos");
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("SocketA"))
        {
            if(!master.socketAPlugged)
            {
                master.socketAPlugged = true;
                transform.position = other.transform.position;
                if(other.CompareTag(correctTag))
                {
                    master.counter+=1;
                }
            }
        }

        if(other.CompareTag("SocketB"))
        {
            if(!master.socketBPlugged)
            {
                master.socketBPlugged = true;
                transform.position = other.transform.position;
                if(other.CompareTag(correctTag))
                {
                    master.counter+=1;
                }
            }
        }

        if(other.CompareTag("SocketC"))
        {
            if(!master.socketCPlugged)
            {
                master.socketCPlugged = true;
                transform.position = other.transform.position;
                if(other.CompareTag(correctTag))
                {
                    master.counter+=1;
                }
            }
        }
        
        if(other.CompareTag("SocketD"))
        {
            if(!master.socketDPlugged)
            {
                master.socketDPlugged = true;
                transform.position = other.transform.position;
                if(other.CompareTag(correctTag))
                {
                    master.counter+=1;
                }
            }
        }
        
    }
}
