using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class graityChanger : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("generar");
    }


    int n;
    GameObject aux;
    public GameObject obj;
    bool isDestroy;
    IEnumerator generar()
    {
        //n = Random.Range(15, 25);
        //yield return new WaitForSeconds(1f);
        aux = Instantiate(obj);
        aux.gameObject.SetActive(true);
        return null;
    }

    private void Update()
    {
        if (isDestroy == true)
        {
            isDestroy = false;
            StartCoroutine("generar");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(aux);
            isDestroy = true;
        }
    }
}
