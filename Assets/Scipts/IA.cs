using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : MonoBehaviour {

    bool facingRight;
	// Use this for initialization
	void Start () {
        facingRight = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeDirection()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);


    }
}
