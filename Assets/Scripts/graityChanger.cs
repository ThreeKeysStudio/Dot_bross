using System.Collections;
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
