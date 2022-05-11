using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoEnemigo : MonoBehaviour
{

    public GameObject jug;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, jug.transform.position, 0.1f);
    }
}
