using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Cinematica : MonoBehaviour
{
    public float tiempo;

    [SerializeField]
    private GameObject Image1;

    [SerializeField]
    private GameObject Image2;

    // Use this for initialization
    void Start () {
        tiempo = 0;
	}
	
	// Update is called once per frame
	void Update () {
        tiempo += Time.deltaTime;
        if (tiempo > 3) {
            //paramos la primera
            Image1.GetComponent<Image>().enabled = false;
        }

        if(tiempo > 9){
            //paramos la segunda imagen
            Image2.GetComponent<Image>().enabled = false;

        }
	}
}
