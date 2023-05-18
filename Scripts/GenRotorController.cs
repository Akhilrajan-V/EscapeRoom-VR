using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenRotorController : MonoBehaviour
{   
    public GameObject RotorTop;
    public GameObject RotorMiddle;
    public GameObject RotorBottom;

    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;
    public GameObject cube4;

    public ButtonCombination _button;
    
    private bool solved = false;

    public bool Rotor1Set = false;
    public bool Rotor2Set = false;
    public bool Rotor3Set = false;


    Quaternion rotorTop_pos;
    Quaternion rotorMiddle_pos;
    Quaternion rotorBottom_pos;


    // Start is called before the first frame update
    void Start()
    {
        rotorTop_pos = RotorTop.transform.rotation; 
        rotorMiddle_pos = RotorMiddle.transform.rotation; 
        rotorBottom_pos = RotorBottom.transform.rotation; 

    }

    // Update is called once per frame
    void Update()
    {
        if (_button.Button_1)
            cube1.SetActive(true);
        if (!_button.Button_1)
            cube1.SetActive(false);

        if (_button.Button_2)
            cube2.SetActive(true);
        if (!_button.Button_2)
            cube2.SetActive(false);

        if (_button.Button_3)
            cube3.SetActive(true);
        if (!_button.Button_3)
            cube3.SetActive(false);

        if (_button.reset)
            cube4.SetActive(true);
        if (!_button.reset)
            cube4.SetActive(false);

        if (_button.reset)
        {
            ResetRotors();
        }

        if(_button.Rotor_Power)
        {
            SpinRotors();
        }
        
        if(_button.Button_1)
        {
            Rotor2Set = true;
        }
        if(_button.Button_2)
        {
            Rotor1Set = true;
        }
        if(_button.Button_3)
        {
            Rotor3Set = true;
        }
        
        SetRotors();

        if(solved)
        {
            SpinRotors();
        }
        
    }

    void SetRotors()
    {
        if(Rotor3Set)
        {
            //RotorTop.transform.Rotate(Vector3.left * 10f * Time.deltaTime);
            RotorTop.transform.Rotate(0f,90f,0f,Space.World);
            //RotorTop.transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
            Rotor3Set = false;
        }
        if (Rotor1Set)
        {
            //RotorMiddle.transform.Rotate(Vector3.left * 10f * Time.deltaTime);
            RotorMiddle.transform.Rotate(0f, 90f, 0f, Space.World);
            //RotorMiddle.transform.rotation = Quaternion.AngleAxis(-90, Vector3.forward);
            Rotor1Set = false;
        }
        if (Rotor2Set)
        {
            //RotorBottom.transform.Rotate(Vector3.left * 10f * Time.deltaTime);
            RotorBottom.transform.Rotate(0f, 90f, 0f, Space.World);
            //RotorBottom.transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
            Rotor2Set = false;
            solved = true;
        }
    }

    void SpinRotors()
    {
        Debug.Log("Done");
    }

    void ResetRotors()
    {
        RotorTop.transform.rotation = Quaternion.RotateTowards(RotorTop.transform.rotation, rotorTop_pos, 10.0f * Time.deltaTime);
        RotorMiddle.transform.rotation = Quaternion.RotateTowards(RotorTop.transform.rotation, rotorMiddle_pos, 10.0f * Time.deltaTime);
        RotorBottom.transform.rotation = Quaternion.RotateTowards(RotorTop.transform.rotation, rotorBottom_pos, 10.0f * Time.deltaTime);
        //RotorTop.transform.rotation = rotorTop_pos; 
        //RotorMiddle.transform.rotation = rotorMiddle_pos; 
        //RotorBottom.transform.rotation = rotorBottom_pos;
    }
}
