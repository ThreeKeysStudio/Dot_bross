using UnityEngine;

public class monedaC : MonoBehaviour
{
    //Variables publicas
    public AudioSource quienEmite;
    public AudioClip sonido;

    //Metodo que controla cuando el jugador ha entrado en contacto con la moneda
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(sonido, gameObject.transform.position);
            
            controladorPuntuacion.setPuntuacion(1);
            Destroy(this.gameObject);
            

        }
    }

}
