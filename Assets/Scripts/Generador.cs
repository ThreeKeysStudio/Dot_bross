using UnityEngine;
using System.Collections.Generic;

public class Generador : MonoBehaviour {
	//Variables publicas
	public GameObject [] obj;
	public List<GameObject> pool;
	public float vel;
	public int num, numaux;

	//variables
	GameObject aux;
	Vector2 mov, mov2, mov3;
	int paux = 15;
	bool first = true;

	//Metodo que se ejecuta al principio y asigna la primera plataforma que se vaya a generar
	void Start () {
		num = Random.Range(0, obj.Length);
	}
	//metodo que se ejecuta a lo largo de todo el juego y genera las plataformas de manera aleatoria
    private void FixedUpdate()
    {
		//Este if controlar que se no se generen las plataformas antes de tiempo
		if (obj[num].transform.position.x <= 10 || first==true || aux.transform.position.x <= 10)
		{
			first = false;
			num = Random.Range(0, obj.Length);

			aux = Instantiate(obj[num]);
			aux.gameObject.SetActive(true);
			pool.Add(aux);
		}

		//los tres objetos que se guardan en la piscina.
		//object1
		mov = pool[0].transform.position;
		
		mov.x -= vel;

		pool[0].transform.position = mov;

		//object2
		if (pool.Count >= 2) {
			

			mov2 = pool[1].transform.position;

			mov2.x -= vel;

			pool[1].transform.position = mov2;
		}
		//object3
		if (pool.Count >= 3)
		{
			

			mov3 = pool[2].transform.position;

			mov3.x -= vel;

			pool[2].transform.position = mov3;
		}
		
		//controlador piscina de objetos
		if (pool.Count == 4)
        {
			Destroy(pool[0]);
			pool.RemoveAt(0);
        }

		//aumento de velocidad dependiendo de la puntuacion
		if ((controladorPuntuacion.p/100) == paux) { 
			paux+=15;
			
			vel += 0.025f;
		}

	}

}
