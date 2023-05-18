using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1Controller : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject p1Trigger1;
    private GameObject p1Trigger2;
    private GameObject p1Trigger3;
   

    public bool Ispuzzle1Solved = false;
    private int p1, p2, p3;
    void Start()
    {
        p1Trigger1 = transform.GetChild(0).gameObject;
        p1Trigger2 = transform.GetChild(1).gameObject;
        p1Trigger3 = transform.GetChild(2).gameObject;
        TimerController.instance.BeginTimer();
    }

    // Update is called once per frame
    void Update()
    {
       Puzzle1Control();
       if(p1+p2+p3 == 3)
       {
            Ispuzzle1Solved = true;
       } 
    }

    void Puzzle1Control()
    {
        if(p1Trigger1.GetComponent<P1Controller1>().solved)
        {
            p1 = 1;
        }
        if(p1Trigger2.GetComponent<P1Controller2>().solved)
        {
            p2 = 1;
        }
        if(p1Trigger3.GetComponent<P1Controller3>().solved)
        {
            p3 = 1;
        }
    }
    
}
