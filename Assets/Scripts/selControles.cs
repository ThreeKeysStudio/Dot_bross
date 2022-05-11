using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selControles : MonoBehaviour
{

    static bool bfle, bjoy=true;
    public static bool jug=false, opciones=false;
    public Text btn, btn2;
    public Button izq;
    public Joystick Jjoy;


    public void Update()
    {
        if (bfle == true && jug==true)
        {
            Jjoy.gameObject.SetActive(false);
            izq.gameObject.SetActive(true);
        }

        if (bjoy == true && jug == true)
        {
            Jjoy.gameObject.SetActive(true);
            izq.gameObject.SetActive(false); 
        }

        if (bfle == true && opciones == true)
        { 
            btn.color = Color.red;
            btn2.color = Color.white;
        }

        if (bjoy == true && opciones == true)
        {
            btn2.color = Color.red;
            btn.color = Color.white;
        }
    }
    public void joy()
    {
        bjoy = true;
        bfle = false;
    }
    public void flechas()
    {
        bfle = true;
        bjoy = false;
    }
}
