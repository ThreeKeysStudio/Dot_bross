using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corazon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            /*if (ControladorVida.vida != 3)
            {
                //Destroy(gameObject);
                //ControladorVida.controlarVida(+1);
            }*/
            
        }
    }
}
