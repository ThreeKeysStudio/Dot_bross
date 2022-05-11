using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
{
    public Transform Tra;
    public Transform Player;
    public Transform limite;
    public Vector3 V3,p;
    float x;
    bool fin=false;


    void LateUpdate()
    {

        
        V3 = Player.position;
        if (V3.x <= 2.950205)
        {
            x = 2.950205f;
        }
        else { 
            x= V3.x;
        }


        if (V3.x > 145.0911)
        {
            x = 145.0911f;
            fin = true;
            limite.position= new Vector3(132.71f, 0.13f, 1.14f);
        }

        if(V3.x <= -7.75)
        {
            fin = false;
        }

        if (V3.y > 2f)
         {

             Tra.position = new Vector3(x, V3.y-2, V3.z - 26);
         }
         else
         {
            if (fin == false)
            {
                Tra.position = new Vector3(x, -0f, V3.z - 26);
            }
             
         }

         
   
  }

}
