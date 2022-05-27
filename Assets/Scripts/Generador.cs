using UnityEngine;
using System.Collections.Generic;

public class Generador : MonoBehaviour {

	public GameObject [] obj;
	public List<GameObject> pool;
	GameObject aux;
	Vector2 mov, mov2, mov3;
	public float vel;
	public int num, numaux;
	int paux=15;
	bool first=true;

	// Use this for initialization
	void Start () {
		num = Random.Range(0, obj.Length);
	}

    private void FixedUpdate()
    {
		if (obj[num].transform.position.x <= 10 || first==true || aux.transform.position.x <= 10)
		{
			first = false;
			num = Random.Range(0, obj.Length);
			if (num <= 1) { 
				
			}

			aux = Instantiate(obj[num]);
			aux.gameObject.SetActive(true);
			pool.Add(aux);
		}

		//object1
		mov = pool[0].transform.position;
		
		mov.x -= vel;

		pool[0].transform.position = mov;

		if (pool.Count >= 2) {
			//object2

			mov2 = pool[1].transform.position;

			mov2.x -= vel;

			pool[1].transform.position = mov2;
		}

		if (pool.Count >= 3)
		{
			//object3

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
