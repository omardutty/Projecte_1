using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuchillazo : MonoBehaviour {

    public GameObject ia;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyUp(KeyCode.E))

            Destroy(ia.gameObject);
    }
}
