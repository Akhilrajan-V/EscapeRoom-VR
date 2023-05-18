using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalController : MonoBehaviour
{   
    public ParticleSystem fog;
    public Transform DoorSpawnPoint;
    public GameObject closedDoor;
    public GameObject openDoor;
    // Start is called before the first frame update
    bool done =false;
    void Start()
    {
        fog.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if(done)
        {
            Destroy(closedDoor);
            Instantiate(openDoor, DoorSpawnPoint);
            done =false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Arrow"))
        {
            fog.Play();
            Destroy(other.gameObject);
            done = true;
        }
    }
}
