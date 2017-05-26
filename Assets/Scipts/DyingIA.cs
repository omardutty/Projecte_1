using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyingIA : MonoBehaviour
{

    public PlayerEnemy player;
    public bool enemyHealth;

    private bool activa;

    private void Update()
    {
        mifuncion();
    }


    void mifuncion()
    {
        if (activa && player.pinchando)
        {

            Destroy(gameObject);

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bala")
        {
            Destroy(gameObject);
        }

        // cuchillazo
         if (collision.name == "Player_Enemy") {

              activa = true;

          }
        else
        {
            activa = false;
        }
    }
    
}
