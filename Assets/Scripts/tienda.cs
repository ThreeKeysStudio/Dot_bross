using UnityEngine;
using UnityEngine.UI;

public class tienda : MonoBehaviour
{
    //variables publicas
    public Text dineroT;

    //metodo que se ejecuta para tener actualizado el dinero en tiempo real
    private void Update()
    {
        dineroT.text= "Dot Coins: " + PlayerPrefs.GetInt("money");
    }
    
    //metodo usado para comprar una "skin"
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
