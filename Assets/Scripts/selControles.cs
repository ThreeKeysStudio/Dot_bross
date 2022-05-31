using UnityEngine;
using UnityEngine.UI;

public class selControles : MonoBehaviour
{
    //variables publicas
    public Text btn, btn2;
    public Button izq;
    public Joystick Jjoy;
    public DynamicJoystick Jdjoy;
    public Toggle tg;
    public static bool jug = false, opciones = false;

    //metodo que actualiza el tipo de control que se usara depende de cual sea el seleccionado en las opciones
    public void Update()
    {
        int control= PlayerPrefs.GetInt("controles");
        

        //flechas
        if (control == 1 && opciones == true)
        { 
            btn.color = Color.red;
            btn2.color = Color.white;
        }
        //Joystick
        if (control == 2 && opciones == true)
        {
            btn2.color = Color.red;
            btn.color = Color.white;
        }
        //Dinamic Joystick
        if (control == 3 && opciones == true)
        {
            
            btn2.color = Color.red;
            btn.color = Color.white;
            tg.isOn = true;
        }
    }
    //Serie de metodos para asignar el control cuando se presiona un boton
    public void joy()
    {
        PlayerPrefs.SetInt("controles", 2);
    }
    public void flechas()
    {
        tg.isOn = false;
        PlayerPrefs.SetInt("controles", 1);
    }
    public void djoy()
    {
        PlayerPrefs.SetInt("controles", 3);
    }
    //Controlador del toggle de las opciones
    public void dinamic(Toggle tgValue)
    {
        if (tgValue == true)
        {
            djoy();
        }
        else
        {
            joy();
        }
    }
}
