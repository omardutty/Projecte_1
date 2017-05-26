
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mision : MonoBehaviour
{
    public PlayerEnemy Player;
    public OBJRecolectable Objetos;
    public bool playeronthezone;

    // Use this for initialization
    void Start()
    {
        Player = FindObjectOfType<PlayerEnemy>();
        Objetos = FindObjectOfType<OBJRecolectable>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.numero == Objetos.contador)
        {
            Player.canpass = true;

            if (Player.canpass == true && playeronthezone == true)
            {
                SceneManager.LoadScene("Default");
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player_Enemy")
        {
            playeronthezone = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player_Enemy")
        {
            playeronthezone = false;
        }
    }
}
