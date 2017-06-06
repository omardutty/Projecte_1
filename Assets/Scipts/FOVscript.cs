using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVscript : MonoBehaviour {

    // Use this for initialization
    public EnemyIA enemy;
    private bool flip = true;
    void start()
    {

    }
    void Update()
    {
        if (enemy.goRight == true && flip == true)
        {
            Debug.Log("giro");
            GetTransform().Rotate(0, -180, 0);
            flip = false;
        }
        else if (enemy.goRight == false && flip == false)
        {
            Debug.Log("giro");
            GetTransform().Rotate(0, 180, 0);
            flip = true;
        }
    }
    

    private Transform GetTransform()
    {
        return transform;
    }
}
