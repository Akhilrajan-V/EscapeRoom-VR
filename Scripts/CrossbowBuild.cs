using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossbowBuild : MonoBehaviour
{   
    [SerializeField] public int counter; 
    public bool pt1 = false;
    public bool pt2 = false;
    public bool pt3 = false;

    [SerializeField] GameObject crossBow;
    [SerializeField] Transform SpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        crossBow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(counter == 3)
        {
            
            crossBow.SetActive(true);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bow_pt1") && !pt1)
        {
            counter +=1;
            pt1 = true;
            Destroy(other.gameObject);
        }
        if(other.CompareTag("Bow_pt2") && !pt2)
        {
            counter +=1;
            pt2 = true;
            Destroy(other.gameObject);
        }
        if(other.CompareTag("Bow_pt3") && !pt3)
        {
            counter +=1;
            pt3 = true;
            Destroy(other.gameObject);
        }
    }
}
