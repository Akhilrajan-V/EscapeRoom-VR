using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireCircuit_Controller : MonoBehaviour
{   
    public bool reset = false;

    public int counter = 0;

    // public bool success = false;
    public bool socketAPlugged = false;
    public bool socketBPlugged = false;
    public bool socketCPlugged = false;
    public bool socketDPlugged = false;

    [SerializeField] private GameObject gen2;
    [SerializeField] private Material _glass;
    [SerializeField] public GameObject crossbowPiece;


    void Start()
    {
        crossbowPiece.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(reset)
        {
            socketAPlugged = false;
            socketBPlugged = false;
            socketCPlugged = false;
            socketDPlugged = false;
            counter = 0;
        }

        if(counter >=4) 
        {
            gen2.GetComponent<Renderer>().material = _glass;
            crossbowPiece.SetActive(true);
        }
    }
    public void MasterReset()
    {
        reset = true;
        Debug.Log("resetting");
        reset = false;
    }
}
