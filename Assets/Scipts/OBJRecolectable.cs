using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJRecolectable : MonoBehaviour {
    public int contador = 0;

    void OnTriggerEnter2D(Collider2D otro){
        if (otro.GetComponent<Collider2D>().tag == "recoger")
        {
            contador += 1;
            //print(contador);
            Destroy(otro.gameObject);
        }
    }
}
