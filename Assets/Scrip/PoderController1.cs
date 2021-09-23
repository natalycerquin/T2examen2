using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoderController1 : MonoBehaviour
{
    private Rigidbody2D rb;

    // Start is called before the first frame update

    private string Enemigo = "Zombie";
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 5f);
    }


    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(5, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(Enemigo))
        {
            Destroy(this.gameObject, 0.1f);
        }
    }

}
