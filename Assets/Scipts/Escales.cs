using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escales : MonoBehaviour {

    public  PlayerEnemy thePlayer;

  
    
    // Use this for initialization
    void Start () {

        thePlayer = FindObjectOfType<PlayerEnemy>();
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player_Enemy")
        {
            thePlayer.onLadder = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player_Enemy")
        {
            thePlayer.onLadder = false;
        }
    }

    // Update is called once per frame
  
}
