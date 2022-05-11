using UnityEngine;
using UnityEngine.UI;

public class tienda : MonoBehaviour
{
    int dinero;
    int dineroC;
    public Text dineroT;
    private void Update()
    {
        dineroT.text= "Dinero: " + PlayerPrefs.GetInt("money");
    }

    public static bool comprar(int valor) {
        int din;
        din = PlayerPrefs.GetInt("money");
        
        if (din >= valor)
        {
            din = PlayerPrefs.GetInt("money") - valor;
            PlayerPrefs.SetInt("money", din);
            return true;
        }
        else
        {
            return false;
        }
    }

}
