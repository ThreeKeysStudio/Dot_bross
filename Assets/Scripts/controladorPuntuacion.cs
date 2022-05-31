using UnityEngine;
using UnityEngine.UI;

public class controladorPuntuacion : MonoBehaviour
{
    //Variables publicas
    public Text puntuacion;
    public static int p;

    //Metodo que se ejecuta al empezar el juego
    void Start()
    {
        p = 0;
    }

    //Metodo que va ejecutandose en bucle para ir aumentando la puntuación del jugador
    void FixedUpdate()
    {
        p += 1;
        puntuacion.text = "Puntuacion: " + (p / 100);
    }

    //Estos son el set y el get de la puntuacion para usarlo en otros lados del programa
    public static void setPuntuacion(int paux) {

        p += paux * 100;
    }

    public static int getPuntuacion(){
        return p;
    }
}
