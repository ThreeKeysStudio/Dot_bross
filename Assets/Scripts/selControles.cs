using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selControles : MonoBehaviour
{

    public static bool jug=false, opciones=false;
    public Text btn, btn2;
    public Button izq;
    public Joystick Jjoy;
    public DynamicJoystick Jdjoy;
    public Toggle tg;


    public void Update()
    {
        int control= PlayerPrefs.GetInt("controles");
        if (control == 1 && jug==true)
        {
            Jjoy.gameObject.SetActive(false);
            izq.gameObject.SetActive(true);
            Jdjoy.gameObject.SetActive(false);
        }

        if (control == 2 && jug == true)
        {
            Jjoy.gameObject.SetActive(true);
            izq.gameObject.SetActive(false);
            Jdjoy.gameObject.SetActive(false);
        }

        if(control == 3 && jug == true)
        {
            Jdjoy.gameObject.SetActive(true);
            Jjoy.gameObject.SetActive(false);
            izq.gameObject.SetActive(false);
        }


        if (control == 1 && opciones == true)
        { 
            btn.color = Color.red;
            btn2.color = Color.white;
            
        }

        if (control == 2 && opciones == true)
        {
            btn2.color = Color.red;
            btn.color = Color.white;
        }

        if (control == 3 && opciones == true)
        {
            
            btn2.color = Color.red;
            btn.color = Color.white;
            tg.isOn = true; ;
        }
    }
    public void joy()
    {
        PlayerPrefs.SetInt("controles", 2);
    }
    public void flechas()
    {
        tg.isOn = false;
        PlayerPrefs.SetInt("controles", 1);
    }
    
    public void dinamic(Toggle tgValue)
    {
        if(tgValue == true)
        {
            djoy();
        }
        else
        {
            joy();
        }
    }
    public void djoy()
    {
        PlayerPrefs.SetInt("controles", 3);
    }

}
