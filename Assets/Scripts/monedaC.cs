using UnityEngine;

public class monedaC : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource quienEmite;
    public AudioClip sonido;
    void Start()
    {
        
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
