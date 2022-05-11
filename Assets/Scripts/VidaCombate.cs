using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaCombate : MonoBehaviour
{
    public Text vida;
    static int punt;
    void Start()
    {
        punt = controladorPuntuacion.getPuntuacion();
        vida.text = "Vida: " + punt;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
