using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puertas : MonoBehaviour {
    public GameObject botiquin;
    public bool isopen = false;
    public float altura;
    private float inicio;

    private void Start()
    {
      
        inicio = GetComponent<Transform>().position.y;
        Debug.Log("fgt");
    }
    // Update is called once per frame
    void Update () {
        if (botiquin == null){
                GetComponent<Transform>().Translate(0, 0.03f, 0);
                Debug.Log("actual "+GetComponent<Transform>().position.y);
                Debug.Log("destiny "+inicio);
            if (GetComponent<Transform>().position.y > inicio + altura /*|| this.transform.position.y > 4*/)
                {
                    Destroy(this);
                 }
            }
        }
	}


