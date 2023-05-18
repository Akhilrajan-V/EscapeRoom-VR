using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCombination : MonoBehaviour
{
    public bool Button_1 = false;
    public bool Button_2 = false;
    public bool Button_3 = false;
    public bool Rotor_Power = false;
    public bool reset = false;
    public GenRotorController rotor;
    //void set_false()
    //{
    //    Button_1 = false;
    //    Button_2 = false;
    //    Button_3 = false;
    //    reset = false;
    //}

    public void Set_Button_1_fn()
    {
        if (Button_2)
            Button_1 = true;
        else
            reset = true;
    }
    public void Set_Button_2_fn()
    {
        reset = false;
        Button_2 = true;
    }
    public void Set_Button_3_fn()
    {
        if (Button_1 && Button_2)
        {
            Button_3 = true;
            Rotor_Power = true;
        }
        else
            reset = true;
    }
}
