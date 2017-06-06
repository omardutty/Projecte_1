using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour {

    private BalaEnemy1 myBala;

    // Use this for initialization

    void Start ()
    {

    }
    
	
	// Update is called once per frame
	void Update () {

        if (Input.anyKey) {

            SceneManager.LoadScene(PlayerPrefs.GetString("AlreadyScene"));
        }
	}
}
