using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private string Poder1 = "Poder1";
    private string Poder2 = "Poder2";
    private string Poder3 = "Poder3";

    private int contador1 = 0;
    private int contador2 = 0;
    private int contador3 = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(Poder1))
        {
            ///Por alguna razon suma de 2 en 2, para que cumpla la condicion
            /// se puso 10, que vendria a ser 5 balas 
            contador1 += 1;
            if (contador1 == 10)
            {
                Destroy(this.gameObject, 0.1f);
            }
        }
        if (other.gameObject.CompareTag(Poder2))
        {
            contador2 += 1;
            /// se puso 4, que vendria a ser 2 balas 
            if (contador2 == 4)
            {
                Destroy(this.gameObject, 0.1f);
            }
        }
        if (other.gameObject.CompareTag(Poder3))
        {
            contador3 += 1;
            if (contador3 == 1)
            {
                Destroy(this.gameObject, 0.1f);
            }
        }
    }
}
