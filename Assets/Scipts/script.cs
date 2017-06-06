using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour {


    private Animator myanimator;
    [SerializeField]
    public bool shooting = false;
	// Use this for initialization
	void Start () {
        myanimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        myanimator.SetBool("Shot", false);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myanimator.SetBool("Shot", true);
            
        }
       
    }
}
