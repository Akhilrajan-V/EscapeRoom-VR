using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gen1 : MonoBehaviour
{
    public int sequenceCount = 0;
    public bool button_1 = false;
    public bool button_2 = false;
    public bool button_3 = false;
    public bool Rotor_Power = false;

    public GameObject RotorTop;
    public GameObject RotorMiddle;
    public GameObject RotorBottom;

    private bool Rotor1Set = true;
    private bool Rotor2Set = true;
    private bool Rotor3Set = true;

    [SerializeField] GameObject crossBowPiece;
    [SerializeField] Transform SpawnPoint;
    [SerializeField] float rotationSpeed = 40f; // Adjust the rotation speed as desired

    Quaternion rotorTop_pos;
    Quaternion rotorMiddle_pos;
    Quaternion rotorBottom_pos;

    [SerializeField] private ParticleSystem fog;

    void Start()
    {
        rotorTop_pos = RotorTop.transform.rotation;
        rotorMiddle_pos = RotorMiddle.transform.rotation;
        rotorBottom_pos = RotorBottom.transform.rotation;
       
        fog.Pause();
    }

    private void Update()
    {
        if (!Rotor_Power)
        {
            if (sequenceCount == 0)
            {
                if (button_2)
                {
                    sequenceCount = 1;
                    button_2 = false;
                }
                else if (button_1 || button_3)
                    ResetSequence();
            }
            else if (sequenceCount == 1)
            {
                if (button_1)
                {
                    sequenceCount = 2;
                    button_1 = false;
                }
                else if (button_2 || button_3)
                    ResetSequence();
            }
            else if (sequenceCount == 2)
            {
                if (button_3)
                {
                    sequenceCount = 3;
                }
                else if (button_2 || button_1)
                    ResetSequence();
            }
            else if (sequenceCount == 3)
            {
                
                Rotor_Power = true;
                Instantiate(crossBowPiece, SpawnPoint.position, SpawnPoint.rotation);
            }
            else
            {
                // Call the reset function if the sequence is interrupted
                ResetSequence();
            }
            SetRotors();
        }
        else
            SpinRotors();
    }

    void SetRotors()
    {
        if (sequenceCount == 1 && Rotor3Set)
        {
            RotorTop.transform.Rotate(0f, 90f, 0f, Space.World);
            Rotor3Set = false;
        }
        if (sequenceCount == 2 && Rotor1Set)
        {
            RotorMiddle.transform.Rotate(0f, 90f, 0f, Space.World);
            Rotor1Set = false;
        }
        if (sequenceCount == 3 && Rotor2Set)
        {
            RotorBottom.transform.Rotate(0f, 90f, 0f, Space.World);
            Rotor2Set = false;
        }
    }

    void SpinRotors()
    {

    // Rotate the rotors incrementally based on the rotation speed and frame rate
    RotorTop.transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.World);
    RotorMiddle.transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.World);
    RotorBottom.transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.World);
    
    fog.Play();

    }

    private void ResetSequence()
    {
        sequenceCount = 0;
        button_2 = false;
        button_1 = false;
        button_3 = false;

        Rotor1Set = true;
        Rotor2Set = true;
        Rotor3Set = true;

        RotorTop.transform.rotation = rotorTop_pos;
        RotorMiddle.transform.rotation = rotorMiddle_pos;
        RotorBottom.transform.rotation = rotorBottom_pos;

        //RotorTop.transform.rotation = Quaternion.RotateTowards(RotorTop.transform.rotation, rotorTop_pos, 10.0f * Time.deltaTime);
        //RotorMiddle.transform.rotation = Quaternion.RotateTowards(RotorTop.transform.rotation, rotorMiddle_pos, 10.0f * Time.deltaTime);
        //RotorBottom.transform.rotation = Quaternion.RotateTowards(RotorTop.transform.rotation, rotorBottom_pos, 10.0f * Time.deltaTime);

    }

    public void SetButton1True()
    {
        button_1 = true;
    }

    public void SetButton2True()
    {
        button_2 = true;
    }

    public void SetButton3True()
    {
        button_3 = true;
    }
}

