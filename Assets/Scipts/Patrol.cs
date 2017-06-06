using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{

    public GameObject startPoint;
    public GameObject endPoint;
   // public Bala balita;

    public bool vida;

    public float enemySpeed;

    private bool facingRight;

    void Start()
    {
        if (!facingRight)
        {
            transform.position = startPoint.transform.position; 
        }
        else
        {
            transform.position = endPoint.transform.position;
        }


    }

    void Update()
    {
       

        if (!facingRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPoint.transform.position, enemySpeed * Time.deltaTime);
            if (transform.position == endPoint.transform.position)
            {
                facingRight = true;
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        if (facingRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPoint.transform.position, enemySpeed * Time.deltaTime);
            if(transform.position == startPoint.transform.position)
            {
                facingRight = false ;
                GetComponent<SpriteRenderer>().flipX = false;
            }
           
        }
    }

   

    public void OnDrawGizmos()
    {

        Gizmos.DrawLine(startPoint.transform.position, endPoint.transform.position);

    }




}

