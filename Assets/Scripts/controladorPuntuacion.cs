using UnityEngine;
using UnityEngine.UI;

public class controladorPuntuacion : MonoBehaviour
{

    public Text puntuacion;
    public static int p;
    void Start()
    {
        p = 0;
    }

    void FixedUpdate()
    {
        p += 1;

        puntuacion.text = "Puntuacion: " + (p / 100);
    }

    public static void setPuntuacion(int paux) {

        p += paux * 100;
    }

    public static int getPuntuacion(){
        return p;
    }
}
