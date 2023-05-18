using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenHub_Controller : MonoBehaviour
{
    public bool triggered = false;

    public Collider hub;

    public GameObject CrossBowPiece;
    public GameObject Circuit_image;
    Rigidbody rb;

    public GameObject gen1;
    public Material _glass;

    private bool cbDone = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        CrossBowPiece.SetActive(false);
        Circuit_image.SetActive(false);
    }
    void Update()
    {
       
        if (triggered)
        {
            gameObject.transform.position = hub.transform.position;
            gameObject.transform.rotation = hub.transform.rotation;
            if (!cbDone){GetCrossBowPiece();}
            
        }
    }
    void OnTriggerEnter(Collider key)
    {
        if(key == hub)
        {
            Debug.Log("Key");
            triggered = true;
        }
    }

    void GetCrossBowPiece()
    {
        CrossBowPiece.SetActive(true);
        Circuit_image.SetActive(true);

        gen1.GetComponent<Renderer>().material = _glass;
        cbDone = true;
    }
}
